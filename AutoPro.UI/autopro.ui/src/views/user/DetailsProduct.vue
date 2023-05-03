<template>
  <div>
    <TheHeader></TheHeader>
    <TheNavbar></TheNavbar>
    <div class="content" id="main">
      <TheLineLink name="Sản phẩm" :detail="'/ ' + product.productName"></TheLineLink>
      <div class="details-product">
        <div class="details-product-image">
          <img :src="product.image" alt="" />
        </div>
        <div class="details-product-right">
          <div class="details-product-name">
            Tên sản phẩm: {{ product.productName }}
          </div>
          <div class="details-product-code">Mã sản phẩm: {{ product.productCode }}</div>
          <div class="details-product-brand">Thương hiệu: {{ brand.brandName }}</div>
          <div class="details-product-brand">Xuất xứ: {{ product.placeOrigin }}</div>
          <div class="details-product-price">Giá tiền: {{ formatMoney(product.price) }} </div>
          <div class="details-product-sell">Đã bán: {{ product.quantitySell }}</div>
          <div class="details-product-sell">Số lượng còn: {{ product.quantity }}</div>
          <div class="details-product-status">Tình trạng : {{ formatStatusProduct(product.quantity - product.quantitySell)
          }}</div>
          <div class="details-product-number">
            <i class="fa-solid fa-minus" style="cursor: pointer;" @click="minusQuantity"></i>
            <MInput style="width: 50px; border-radius: 1px" v-model="this.number"></MInput>
            <i class="fa-solid fa-plus" style="cursor: pointer;" @click="addQuantity"></i>
          </div>
          <div class="details-product-order" @click="addCart">
            <button>Đặt hàng</button>
          </div>
          <div class="details-product-describe">Mô tả : {{ product.description }}</div>
          <div class="details-product-commit">
            Thông tin thêm
            <p>
              <i class="fa-solid fa-circle-check" style="color: #11990f"></i>
              Đảm bảo giá thấp nhất
            </p>
            <p>
              <i class="fa-solid fa-circle-check" style="color: #11990f"></i>
              Cam kết đúng chất lượng và chủng loại sản phẩm
            </p>
            <p>
              <i class="fa-solid fa-circle-check" style="color: #11990f"></i>
              Hoàn trả 100% chi phí đặt trước nếu không đảm bảo chất lượng sản
              phẩm
            </p>
          </div>
          <div class="detail-product-comment">Đánh giá</div>
          <div class="list-comment">
            <div class="user-comment">
              <div class="user-comment-img">
                <img src="../../assets/Image/giamsoc.jpg" alt="" />
              </div>
              <div class="user-comment-conten">
                <div class="username-comment">Pham Đức Đăng</div>
                <div class="user-content-comment">Nội dung đánh giá</div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <div class="line-footer"></div>
      <div class="new-products-imported">
        <div class="title">SẢN PHẨM TƯƠNG TỰ</div>
        <div class="list-product-impoted">
          <div v-for="(item, index) in dataProductNews" :key="index">
            <div>
              <!-- <router-link :to="'/product/' + item.productID" style="text-decoration: none;color: black;"
              @click="detailProduct(item.productID)"> -->
              <div class="product">
                <div class="product-image">
                  <img :src="item.image" alt="" @click="favoriteProduct(item)">
                  <div class="favourtive">
                    <i class="fa-solid fa-heart"></i>
                  </div>
                </div>
                <div class="product-name">{{ item.productName }}</div>
                <div class="price">{{ item.price }}</div>
                <div class="product-buttom">
                  <div class="product-detail" @click="detailProduct(item.productID)">Xem chi tiết</div>
                  <div class="add-cart" @click="addCart2(item)">Thêm vào giỏ hàng</div>
                </div>
              </div>
              <!-- </router-link> -->
            </div>
          </div>
        </div>
        <div class="see-more" @click="seeMoreImported">Xem thêm</div>
      </div>
    </div>
    <TheFooter></TheFooter>
    <MLoading v-if="showLoading"></MLoading>
  </div>
</template>
  
<script>
import MInput from "@/components/MInput.vue";
import MLoading from "@/components/MLoading.vue";
import TheFooter from "@/layout/TheFooter.vue";
import TheHeader from "@/layout/TheHeader.vue";
import TheLineLink from "@/layout/TheLineLink.vue";
import TheNavbar from "@/layout/TheNavbar.vue";
import axios from 'axios';
import { formatStatusProduct, formatDate, formatMoney } from '@/js/gCommon'
import ApiProduct from '../../js/apiProduct';
import ApiBrand from '../../js/apiBrand';
export default {
  /**
   * Tên component
   */
  name: "DetailsProduct",
  /**
   * Hứng nhận
   */
  props: {
    id: {
      type: String,
      required: true
    }
  },
  /**
   * Component được sử dụng
   */
  components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput, MLoading },
  /**
   * Emit sự thay đổi
   */
  emits: [""],
  directives: {},
  /**
   * Data
   */
  data() {
    return {
      showLoading: false,
      product: {},
      brand: {},
      dataProductNews: {},
      pageSize: 4,
      productCart: {
        quantitys: ''
      },
      number: 1,
      productCart2: {
        quantitys2: ''
      },
      number2: 1,
      textSearch: '',
      productFavorite: {},
    };
  },
  /**
   * Phương thức
   */
  methods: {
    formatMoney(money) {
      return formatMoney(money);
    },

    formatStatusProduct(status) {
      return formatStatusProduct(status);
    },

    async getBrand(id) {
      await axios.get(ApiBrand.getBrandByID(id))
        .then((res) => {
          this.brand = res.data;
          this.textSearch = res.data.brandName;
          // console.log(this.brand);
        })
    },

    detailProduct(item) {
      this.getProductByID(item);
    },

    getProductNews() {
      this.showLoading = true;
      setTimeout(() => {
        axios.get(ApiProduct.filterProduct(this.textSearch, this.pageSize, 1))
          .then((res) => {
            if (res.status == 200) {
              this.showLoading = false;
              this.dataProductNews = res.data.data;
            } else {
              this.showLoading = false;
              this.dataProductNews = null;
            }
          })
      }, 500);
    },

    seeMoreImported() {
      this.pageSize = this.pageSize + 4;
      this.getProductNews();
    },

    addCart() {
      this.productCart = { ...this.product };
      this.productCart.quantitys = this.number;
      // console.log(this.productCart);
      this.$store.commit('addToCart', this.productCart);
      this.$router.push('/cart');
    },

    addCart2(data) {
      this.productCart2 = data;
      this.productCart2.quantitys2 = this.number2;
      // console.log(this.productCart);
      this.$store.commit('addToCart', this.productCart2);
      this.$router.push('/cart');
    },

    minusQuantity() {
      this.number = this.number - 1;
    },

    addQuantity() {
      this.number = this.number + 1;
    },

    getProductByID(value) {
      // Khởi tạo lấy giá trị id truyền vào
      if (value) {
        // Bật loadding
        this.showLoading = true;
        setTimeout(async () => {
          //Lấy dữ liệu
          await axios.get(ApiProduct.getProductByID(value))
            .then((res) => {
              this.showLoading = false;
              this.product = res.data;
              this.getBrand(this.product.brandID);
              this.getProductNews();
              // console.log("pro", this.product);
            })
        }, 500)
      }
    },

    favoriteProduct(data) {
      this.productFavorite = data;
      this.$store.commit('addToFavorite', this.productFavorite);
    }
  },
  created() {
    let id = this.$route.params.id;
    this.getProductByID(id);
  },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {
    '$route.params.id': function (newVal) {
      this.getProductByID(newVal);
    },
  },
};
</script>
  
<style>
@import url(../../css/detailsproduct.css);
</style>