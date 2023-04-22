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

  },
  watch: {
    // roleApp(newVal) {
    //   if (newVal == "Admin") {
    //     this.$router.push('/admin/dashload');
    //   } else if (newVal == "User" || newVal == null) {
    //     this.$router.push('/');
    //   }
    // }
  }
}
</script>

<style>
@import url(../src/css/main.css);
</style>
