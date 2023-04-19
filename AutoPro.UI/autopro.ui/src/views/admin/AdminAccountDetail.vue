<template>
  <div class="aform-detail">
    <div class="aform-account">
      <div class="aform-title">Tiêu đề form</div>
      <div class="agroup1">
        <div class="acol1">
          Account :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Password :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Tài khoản :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Mật khẩu :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Họ :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Tên :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Họ và tên :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Ngày sinh :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Ngày sinh :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Giới tính :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Địa chỉ :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Điện thoại :
          <MInput></MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          Email :
          <MInput></MInput>
        </div>
        <div class="acol2">
          Ảnh :
          <MInput></MInput>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import MInput from '@/components/MInput.vue';
export default {
  /**
   * Tên component
   */
  name: "AdminAccountDetail",
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { MInput },
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
    };
  },
  /**
   * Phương thức
   */
  methods: {
  },
  created() {},
  /**
   * Theo dõi sự thay đổi
   */
  watch: {},
};
</script>

<style>
@import url(../../css/admin/adminaccount.css);
</style>