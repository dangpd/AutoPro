<template>
  <div>
    <router-view />
  </div>
</template>

<script>

export default {
  name: 'App',
  data() {
    return {
      roleApp: '',
    }
  },
  components: {
  },
  created() {
    const role = localStorage.getItem("Role");
    this.roleApp = role;
    if (this.roleApp == "Admin") {
      this.$router.push('/admin/dashload');
    } else if (this.roleApp == "User" || this.roleApp == null) {
      this.$router.push('/');
    } 
  },
  watch: {
    roleApp(newVal) {
      if (newVal == "Admin") {
        this.$router.push('/admin/dashload');
      } else if (newVal == "User" || newVal == null) {
        this.$router.push('/');
      }
    }
  }
}
</script>

<style>
@import url(../src/css/main.css);
</style>
