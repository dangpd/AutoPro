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
          <router-link to="/product/:id" style="text-decoration: none;color: black;">
            <div class="product">
              <div class="product-image">
                <img src="../../assets/Image/giamsoc.jpg" alt="">
                <div class="favourtive">
                  <i class="fa-solid fa-heart"></i>
                </div>
              </div>
              <div class="product-name">Lốc gió</div>
              <div class="price">Giá : 330.000Vnd</div>
              <div class="product-buttom">
                <div class="product-detail">Xem chi tiết</div>
                <div class="add-cart">Thêm vào giỏ hàng</div>
              </div>
            </div>
          </router-link>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
        </div>
        <div class="see-more">Xem thêm</div>
      </div>
      <div class="new-products-imported">
        <div class="title">PHỤ TÙNG BÁN NHIỀU NHẤT</div>
        <div class="list-product-impoted">
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
          <div class="product">
            <div class="product-image">
              <img src="../../assets/Image/giamsoc.jpg" alt="">
              <div class="favourtive">
                <i class="fa-solid fa-heart"></i>
              </div>
            </div>
            <div class="product-name">Lốc gió</div>
            <div class="price">Giá : 330.000Vnd</div>
            <div class="product-buttom">
              <div class="product-detail">Xem chi tiết</div>
              <div class="add-cart">Thêm vào giỏ hàng</div>
            </div>
          </div>
        </div>
        <div class="see-more">Xem thêm</div>
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
      id: '',
      dataBrand: {},
      rowSelected: -1,
      showLoading: false,
      textSearch: "",
      pageSize: 10,
      pageNumber: 1,
      showSeeMore: false,
    }
  },
  mounted() {
  },
  /**
   * Phương thức
   */
  methods: {
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
  },
  created() {
    const role = localStorage.getItem("Role");
    if (role == "Admin") {
      this.$router.push('/forbidden');
    }
    this.showLoading = true;
    setTimeout(() => {
      this.getAllBrand();
      this.showLoading = false;
    }, 1000)
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