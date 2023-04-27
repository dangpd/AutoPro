<template>
  <div>
    <TheHeader></TheHeader>
    <TheNavbar></TheNavbar>
    <div class="content">
      <MLoading v-if="showLoading"></MLoading>
      <div class="line-content"></div>
      <div class="brand-products">
        <div class="title">PHỤ TÙNG THEO NHÀ SẢN XUẤT</div>
        <div class="list-brand">
          <i class="fa-solid fa-circle-left fa-lg"></i>
          <div class="nav-list-brand" ref="listBrand" v-for="(item, index) in dataBrand" :key="index">
            <div class="item-brand">
              <img :src="item.image" alt="">
            </div>
          </div>
          <i class="fa-solid fa-circle-right fa-lg"></i>
        </div>
      </div>
      <div class="new-products-imported">
        <div class="title">SẢN PHẨM MỚI NHẬP VỀ</div>
        <div class="list-product-impoted">
          <div v-for="(item, index) in dataProductNews" :key="index"
            :class="{ 'row-selected': rowSelected == item.productID }">
            <!-- <router-link :to="'/product/' + item.productID" style="text-decoration: none;color: black;"> -->
            <div>
              <div class="product">
                <div class="product-image">
                  <img :src="item.image" alt="">
                  <div class="favourtive" @click="favoriteProduct(ỉtem)">
                    <i class="fa-solid fa-heart"></i>
                  </div>
                </div>
                <div class="product-name">{{ item.productName }}</div>
                <div class="price">{{ formatMoney(item.price) }}</div>
                <div class="product-buttom">
                  <div class="product-detail" @click="detailProduct(item.productID)">Xem chi tiết</div>
                  <div class="add-cart" @click="addCart(item)">Thêm vào giỏ hàng</div>
                </div>
              </div>
              <!-- </router-link> -->
            </div>
          </div>
        </div>
        <div class="see-more" @click="seeMoreImported">Xem thêm</div>
      </div>
      <div class="new-products-imported">
        <div class="title">PHỤ TÙNG BÁN NHIỀU NHẤT</div>
        <div class="list-product-impoted">
          <div v-for="(item, index) in dataProductNews" :key="index"
            :class="{ 'row-selected': rowSelected == item.productID }">
            <!-- <router-link :to="'/product/' + item.productID" style="text-decoration: none;color: black;"> -->
            <div>
              <div class="product">
                <div class="product-image">
                  <img :src="item.image" alt="">
                  <div class="favourtive">
                    <i class="fa-solid fa-heart"></i>
                  </div>
                </div>
                <div class="product-name">{{ item.productName }}</div>
                <div class="price">{{ formatMoney(item.price) }}</div>
                <div class="product-buttom">
                  <div class="product-detail" @click="detailProduct(item.productID)">Xem chi tiết</div>
                  <div class="add-cart" @click="addCart(item)">Thêm vào giỏ hàng</div>
                </div>
              </div>
            </div>
            <!-- </router-link> -->
          </div>
        </div>
        <div class="see-more" @click="seeMoreImported2">Xem thêm</div>
      </div>
    </div>
    <TheFooter></TheFooter>
  </div>
</template>
<script>
import MLoading from '@/components/MLoading.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import axios from 'axios';
import ApiBrand from '../../js/apiBrand';
import ApiProduct from '../../js/apiProduct';
import { formatMoney } from '@/js/gCommon';
export default {
  /**
   * Tên component
   */
  name: 'Home',
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { TheHeader, TheNavbar, TheFooter, MLoading },
  /**
   * Emit sự thay đổi
   */
  emits: [""],
  directives: {

  },
  /**
   * Data
   */
  data() {
    return {
      showPopup: false,
      role: '',
      id: '',
      dataBrand: {},
      rowSelected: -1,
      showLoading: false,
      textSearch: "",
      pageSize: 8,
      pageNumber: 1,
      showSeeMore: false,
      dataProductNews: {},
      productCart: {
        quantitys: ''
      },
      number: 1,
      productFavorite: {},
    }
  },
  mounted() {
  },
  /**
   * Phương thức
   */
  methods: {
    formatMoney(money) {
      return formatMoney(money);
    },

    getAllBrand() {
      axios.get(ApiBrand.getAll())
        .then((res) => {
          if (res.status == 200) {
            this.dataBrand = res.data;
          } else {
            this.dataBrand = null;
          }
        })
    },

    getProductNews() {
      this.showLoading = true;
      setTimeout(() => {
        axios.get(ApiProduct.filterProduct('', this.pageSize, this.pageNumber))
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
      this.pageSize = this.pageSize + 8;
      this.getProductNews();
    },

    seeMoreImported2() {
      this.pageSize = this.pageSize + 8;
      this.getProductNews();
    },

    detailProduct(item) {
      this.$router.push({ name: 'product', params: { id: item } });
    },

    addCart(data) {
      this.productCart = data;
      this.productCart.quantitys = this.number;
      // console.log(this.productCart);
      this.$store.commit('addToCart', this.productCart);
    },

    favoriteProduct(data) {
      if (!this.role) {
        alert("Bạn chưa đăng nhập");
      } else {
        this.productFavorite = data;
        this.$store.commit('addToCart', this.productFavorite);
      }
    }
  },

  created() {
    const role = localStorage.getItem("Role");
    this.role = role;
    if (role == "Admin") {
      this.$router.push('/forbidden');
    }
    this.showLoading = true;
    setTimeout(() => {
      this.getAllBrand();
      this.getProductNews();
      this.showLoading = false;
    }, 500)
  },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {

  }
}
</script>

<style>
@import url(../../css/home.css);
</style>