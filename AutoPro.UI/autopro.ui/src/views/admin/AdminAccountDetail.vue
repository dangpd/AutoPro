<template>
  <div class="aform-detail">
    <div class="aform-account">
      <div class="aform-title">
        <div class="aform-title-left">
          Tiêu đề form
        </div>
        <div class="onClose" @click="onClose">
          <i class="fa-regular fa-circle-xmark"></i>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Account :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Password :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Tài khoản :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Mật khẩu :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Họ :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Tên :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Họ và tên :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Ngày sinh :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Ngày sinh :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Giới tính :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Địa chỉ :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Điện thoại :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1">
          <div class="acol1-text">
            Email :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
        <div class="acol2">
          <div class="acol2-text">
            Ảnh :
          </div>
          <MInput type="text"
            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            v-model="user">
          </MInput>
        </div>
      </div>
      <div class="aformSave">
        <button>Lưu</button>
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
  emits: ["onClose"],
  directives: {},
  /**
   * Data
   */
  data() {
    return {
      user: ''
    };
  },
  /**
   * Phương thức
   */
  methods: {
    onClose() {
      this.$emit("onClose");
    }
  },
  created() { },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {},
};
</script>

<style>
@import url(../../css/admin/adminaccount.css);
</style>