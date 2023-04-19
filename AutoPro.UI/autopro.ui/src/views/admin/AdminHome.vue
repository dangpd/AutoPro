<template>
  <div>
    <div class="ahomecontent">
      <AdminNavbar @infoAdmin="infoAdmin"></AdminNavbar>
      <div class="arouter-view-content">
        <router-view></router-view>
      </div>
    </div>
    <AdminInfo v-if="showPopup" @onClose="showPopup = false"></AdminInfo>
  </div>
</template>

<script>
import AdminNavbar from '@/layout/AdminNavbar.vue';
import AdminInfo from './AdminInfo.vue';

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
  components: { AdminNavbar, AdminInfo },
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
    }
  },
  /**
   * Phương thức
   */
  methods: {
    infoAdmin() {
      this.showPopup = true;
    }
  },
  created() {

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