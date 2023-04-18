<template>
  <div>
    <div class="login">
      <img src="../../assets/Image/bglogin.png" alt="" />

      <div class="form-register">
        <div class="title-form">ĐĂNG KÍ</div>
        <div class="form-input">
          <div class="register-account">
            <div class="text">Tên đăng nhập :</div>
            <MInput
              type="text"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-account">
            <div class="text">Họ :</div>
            <MInput
              type="text"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-account">
            <div class="text">Tên :</div>
            <MInput
              type="text"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-fullName">
            <div class="text">Họ và tên :</div>
            <MInput
              type="text"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-address">
            <div class="text">Địa chỉ :</div>
            <MInput
              type="text"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div
            class="register-account"
            style="display: flex; align-items: center"
          >
            <div class="text">Avatar :</div>
            <div style="display: flex;align-items: center;">
              <input type="file" ref="fileInput" @change="handleFileUpload()" />
              <p style="color: blue; padding-left: 20px;padding-top: 16px;">
                {{ this.labelProcess }}
              </p>
            </div>
          </div>
          <div class="register-birth">
            <div class="text">Ngày sinh :</div>
            <MInput
              type="date"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-gender">
            <div class="text">Giới tính :</div>
            <div class="gender">
                <input type="radio" name="" id="" style="margin-right: 10px;" ref="male">Nam
                <input type="radio" name="" id="" style="margin:0 10px;" ref="male">Nữ
                <input type="radio" name="" id="" style="margin-left: 10px;margin-right: 10px" ref="male">Khác
            </div>
          </div>
          <div class="register-password">
            <div class="text">Mật khẩu :</div>
            <MInput
              type="password"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
          <div class="register-password">
            <div class="text">Nhập lại mật khẩu :</div>
            <MInput
              type="password"
              styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            >
            </MInput>
          </div>
        </div>
        <div class="submit">
          <input
            type="submit"
            value="Đăng kí"
            style="padding: 4px"
            @click="register"
          />
        </div>
        <div class="orther">
          <router-link to="/account/sign-up" class="sign-up"
            >Đăng nhập</router-link
          >
          hoặc
          <router-link to="/account/forgot-password" class="forgot-password"
            >Quên mật khẩu ?</router-link
          >
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import TheFooter from "@/layout/TheFooter.vue";
import TheHeader from "@/layout/TheHeader.vue";
import TheNavbar from "@/layout/TheNavbar.vue";
import MInput from "@/components/MInput.vue";
import TheLineLink from "@/layout/TheLineLink.vue";
import axios from "axios";
import { app, storage } from "../../js/firebase";
import {
  getDownloadURL,
  getStorage,
  ref,
  uploadBytes,
  uploadBytesResumable,
} from "firebase/storage";
export default {
  /**
   * Tên component
   */
  name: "Register",
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { TheHeader, TheNavbar, TheFooter, MInput, TheLineLink },
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
      //   file: null,
      imageUrl: null,
      labelProcess: "",
    };
  },
  /**
   * Phương thức
   */
  methods: {
    handleFileUpload: async function () {
      //   const storageRef = ref(storage, "user/" + this.file.name);
      //   console.log(this.$refs.fileInput.files[0]);
      //   uploadBytes(storageRef,this.$refs.fileInput.files[0])
      //   .then((snapshot) => {
      //     console.log("ok");
      //   });
      let file = this.$refs.fileInput.files[0];
      const storage = getStorage();
    //   const metadata = {
    //     contentType: "image/jpeg/png",
    //   };
      const storageRef = ref(storage, "Users/" + file.name);
      const uploadTask = uploadBytesResumable(
        storageRef,
        this.$refs.fileInput.files[0],
        // metadata
      );
      uploadTask.on(
        "state_changed",
        (snapshot) => {
          let process = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
          console.log(process);
          this.labelProcess = "Đang tải : " + process + "%";
          if (process == 100) {
            this.labelProcess = "Đã tải xong : " + process + "%";
          }
        },
        (error) => {
          alert("Tải ảnh lỗi");
        },
        () => {
          // Handle successful uploads on complete
          // For instance, get the download URL: https://firebasestorage.googleapis.com/...
          getDownloadURL(uploadTask.snapshot.ref).then((downloadURL) => {
            console.log(downloadURL);
          });
          // uploadTask.snapshot.ref.getDownloadURL().then((downloadURL) => {
          //   console.log(downloadURL);
          //   //   this.product.images.push(downloadURL);
          // });
        }
      );
    },
    
  },
  created() {},
  /**
   * Theo dõi sự thay đổi
   */
  watch: {
    
  },
};
</script>

<style>
@import url(../../css/form.css);
</style>