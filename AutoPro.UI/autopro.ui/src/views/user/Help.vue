<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content-help">
            <TheLineLink name="Trợ giúp"></TheLineLink>
            <div class="help">
                <div class="nav-help">
                    <div class="nav-title">AUTOPRO trợ giúp</div>
                    <div>
                        <div class="nav-help-item">
                            <router-link to="/helps/pay-ment" class="payment">Phương thức thanh toán</router-link>
                        </div>
                        <div class="nav-help-item">
                            <router-link to="/helps/guarantee" class="guarantee">Bảo hành sản phẩm</router-link>
                        </div>
                        <div class="nav-help-item">
                            <router-link to="/helps/free-ship" class="freeship">Miễn phí vận chuyển</router-link>
                        </div>
                    </div>
                </div>
                <div class="nav-help-content">
                    <router-view></router-view>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import Payment from './Payment.vue';
export default {
    /**
         * Tên component
         */
    name: 'Help',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheLineLink, TheFooter, Payment },
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

        }
    },
    /**
     * Phương thức
     */
    methods: {

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
@import url(../../css/help.css);
</style>