<template>
  <div class="aform-detail">
    <div class="aform-account">
      <div class="aform-title">
        <div class="aform-title-left">
          {{ this.title }}
        </div>
        <div class="onClose" @click="onClose">
          <i class="fa-regular fa-circle-xmark"></i>
        </div>
      </div>
      <div class="agroup1" style="padding: 0 20px;">
        <div class="acol12" style="margin: 15px 0;">
          <div class="acol2-text">
            Tài khoản :
          </div>
          <MInput type="text" v-model="user.account"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol12" style="margin: 15px 0;">
          <div class="acol2-text">
            Mật khẩu :
          </div>
          <MInput type="text" v-model="user.password"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol11" style="margin:15px 0">
          <div class="acol1-text">
            Email :
          </div>
          <MInput type="text" v-model="user.email"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
      </div>
      <div class="agroup1" style="padding: 0 20px;">
        <div class="acol11" style="margin:15px 0">
          <div class="acol1-text">
            Họ :
          </div>
          <MInput type="text" v-model="user.firstName"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol12" style="margin: 15px 0;">
          <div class="acol2-text">
            Tên :
          </div>
          <MInput type="text" v-model="user.lastName"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol11" style="margin:15px 0">
          <div class="acol1-text">
            Họ và tên :
          </div>
          <MInput type="text" v-model="user.fullName"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
      </div>
      <div class="agroup1" style="padding: 0 20px;">
        <div class="acol11" style="margin:15px 0">
          <div class="acol1-text">
            Ngày sinh :
          </div>
          <MInput type="text" v-model="user.dateOfBirth"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol12" style="margin: 15px 0;">
          <div class="acol2-text">
            Giới tính :
          </div>
          <MInput type="text" v-model="user.gender"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
        <div class="acol11" style="margin:15px 0">
          <div class="acol1-text">
            Địa chỉ :
          </div>
          <MInput type="text" v-model="user.address"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
      </div>
      <div class="agroup1" style="padding: 0 20px;">
        <div class="acol12" style="margin: 15px 0;">
          <div class="acol2-text">
            Điện thoại :
          </div>
          <MInput type="text" v-model="user.phoneNumber"
            styleInput="width: calc(250px); height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;margin-right:15px;">
          </MInput>
        </div>
      </div>
      <div class="agroup1">
        <div class="acol1-image">
          <div class="aco1-image-file">
            <div class="acol1-text">
              Hình ảnh :
            </div>
            <input type="file" ref="fileInput" @change="handleFileUpload()" />
          </div>
          <img :class="{ 'ImageNone': ImageNone }" :src="srcImage" alt=""
            style="height: 100px;width: 100px;display: none;border: 1px solid #bbb;margin-left: 150px;margin-top: 10px;">
        </div>
      </div>
      <div class="acol2-link">
        <div class="acol1-text" style="width: 150px;">
          Linh đường dẫn :
        </div>
        <MInput type="text" v-model="user.image" styleInput="width: 900px; height: 30px;">
        </MInput>
      </div>
      <div class="aformSave" @click="saveUser">
        <button>Lưu</button>
      </div>
    </div>
    <MLoading v-if="showLoading"></MLoading>
  </div>
</template>

<script>
import MInput from '@/components/MInput.vue';
import MLoading from '@/components/MLoading.vue';
import Resource from '../../js/gResource';
import axios from 'axios';
import ApiUser from '../../js/apiUser';
import {
  getDownloadURL,
  getStorage,
  ref,
  uploadBytesResumable,
} from "firebase/storage";
export default {
  /**
   * Tên component
   */
  name: "AdminAccountDetail",
  /**
   * Hứng nhận
   */
  props: ["id", "type"],
  /**
   * Component được sử dụng
   */
  components: { MInput, MLoading },
  /**
   * Emit sự thay đổi
   */
  emits: ["onClose", "success"],
  directives: {},
  /**
   * Data
   */
  data() {
    return {
      showLoading: false,
      user: {},
      title: '',
      title: '',
      srcImage: "",
      ImageNone: false
    };
  },
  /**
   * Phương thức
   */
  methods: {
    async handleFileUpload() {
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
        this.$refs.fileInput.files[0]
        // metadata
      );

      uploadTask.on(
        "state_changed",
        (snapshot) => {
          // console.log(snapshot);
          let process = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
          // console.log(process);
          if (process == 100) {
            console.log("tải ảnh lên thành công");
          }
        },
        (error) => {
          console.log(error);
          alert("Tải ảnh lỗi");
        },
        () => {
          // uploadTask.pause();
          // Handle successful uploads on complete
          // For instance, get the download URL: https://firebasestorage.googleapis.com/...
          getDownloadURL(uploadTask.snapshot.ref).then((downloadURL) => {
            // console.log(downloadURL);
            this.srcImage = downloadURL;
            this.ImageNone = true;
            this.user.image = downloadURL;
            alert("Đã tải ảnh xong");
          });
        }
      );
    },
    onClose() {
      this.$emit("onClose");
    },

    async saveUser() {
      if (this.type == Resource.FormAdminType.Add) {
        await axios.post(ApiUser.addUser(), this.user)
          .then((res) => {
            if (res.status == 201) {
              this.$emit("onClose");
              this.$emit("success");
            }
          })
          .catch((err) => {
            console.log(err);
          })
      } else {
        this.user.image = this.srcImage;
        await axios.put(ApiUser.updateUser(this.id), this.user)
          .then((res) => {
            if (res.status == 200) {
              this.$emit("success");
              this.$emit("onClose");
            }
          })
          .catch((err) => {
            console.log(err);
          })
      }
    }
  },
  created() {
    this.srcImage = "";
    // Khởi tạo lấy giá trị id truyền vào
    if (this.id) {
      // Bật loadding
      this.showLoading = true;
      setTimeout(() => {
        this.title = Resource.TitleFormAdmin.UpdateAccount;
        //Lấy dữ liệu
        axios.get(ApiUser.getUserById(this.id))
          .then((res) => {
            this.showLoading = false;
            this.user = res.data;
            // console.log(this.user);
            this.srcImage = res.data.image;
            this.ImageNone = true;
            // console.log(this.srcImage);
          })
      }, 1000)
    } else {
      this.title = Resource.TitleFormAdmin.AddAccount;
    }
  },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {
    srcImage(newVal) {
      this.user.image = newVal;
    }
  },
};
</script>

<style>
@import url(../../css/admin/adminaccount.css);
</style>