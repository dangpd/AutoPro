<template>
  <div>
    <TheHeader></TheHeader>
    <TheNavbar></TheNavbar>
    <div class="content">
      <TheLineLink name="Sản phẩm" detail="/ Chi tiết sản phẩm"></TheLineLink>
      <div class="details-product">
        <div class="details-product-image">
          <img src="../../assets/Image/giamsoc.jpg" alt="" />
        </div>
        <div class="details-product-right">
          <div class="details-product-name">
            Giảm sóc akdnj sdjnc sdfkjn sdfkjnsd sdfkjn
          </div>
          <div class="details-product-code">Mã sản phẩm : 1234567</div>
          <div class="details-product-brand">Thương hiệu : Toyata</div>
          <div class="details-product-price">Giá tièn : 900.000 vnd</div>
          <div class="details-product-status">Tình trạng : Còn hàng</div>
          <div class="details-product-number">
            <i class="fa-solid fa-minus"></i>
            <MInput style="width: 50px; border-radius: 1px"></MInput>
            <i class="fa-solid fa-plus"></i>
          </div>
          <div class="details-product-order">
            <router-link to="/cart">
              <button>Đặt hàng</button>
            </router-link>
          </div>
          <div class="details-product-describe">Mô tả</div>
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
          <!-- <div class="write-comment">
            <div style="display: flex;align-items: center;">
              Viết đánh giá
              <MInput></MInput>
            </div>
            <button>Gửi</button>
          </div> -->
        </div>
      </div>
      <div class="line-footer"></div>
      <div class="new-products-imported">
        <div class="title">SẢN PHẨM TƯƠNG TỰ</div>
        <div class="list-product-impoted">
          <router-link
            to="/product/:id"
            style="text-decoration: none; color: black"
          >
            <div class="product">
              <div class="product-image">
                <img src="../../assets/Image/giamsoc.jpg" alt="" />
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
              <img src="../../assets/Image/giamsoc.jpg" alt="" />
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
              <img src="../../assets/Image/giamsoc.jpg" alt="" />
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
              <img src="../../assets/Image/giamsoc.jpg" alt="" />
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
import MInput from "@/components/MInput.vue";
import TheFooter from "@/layout/TheFooter.vue";
import TheHeader from "@/layout/TheHeader.vue";
import TheLineLink from "@/layout/TheLineLink.vue";
import TheNavbar from "@/layout/TheNavbar.vue";

export default {
  /**
   * Tên component
   */
  name: "DetailsProduct",
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput },
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
      nameproduct: "dang",
    };
  },
  /**
   * Phương thức
   */
  methods: {},
  created() {},
  /**
   * Theo dõi sự thay đổi
   */
  watch: {},
};
</script>
  
<style>
@import url(../../css/detailsproduct.css);
</style>