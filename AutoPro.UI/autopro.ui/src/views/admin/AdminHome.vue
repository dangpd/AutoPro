<template>
  <div>
    <div class="ahomecontent">
      <AdminNavbar @infoAdmin="infoAdmin"></AdminNavbar>
      <div class="arouter-view-content">
        <router-view></router-view>
      </div>
    </div>
    <AdminInfo v-if="showPopup" @onClose="showPopup = false" :id="userID" @success="success"></AdminInfo>
  </div>
</template>

<script>
import AdminNavbar from '@/layout/AdminNavbar.vue';
import AdminInfo from './AdminInfo.vue';
import axios from 'axios';
import ApiUser from '@/js/apiUser';
export default {
  /**
         * Tên component
         */
  name: 'AdminHome',
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { AdminNavbar, AdminInfo, },
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
      showLoading: false,
      admin: {},
      userID: ''
    }
  },
  /**
   * Phương thức
   */
  methods: {
    infoAdmin() {
      this.showPopup = true;
    },
    success() {

    },
    getAdmin() {
      const login = localStorage.getItem("UserID");
      this.userID = login;
      // console.log(this.userID);
      if (this.userID != null) {
        axios.get(ApiUser.getUserById(login))
          .then((res) => {
            if (res.status == 200) {
              this.admin = res.data;
              // console.log(this.admin);
            }
          })
      }
    }
  },
  created() {
    this.getAdmin();
  },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {

  }
}
</script>

<style>
@import url(../../css/admin/adminhome.css);
</style>