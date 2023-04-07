<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Sản phẩm yêu thích"></TheLineLink>
            <div class="products-favorite">
                <div class="productf">
                    <div class="productf-image">
                        <img src="../../assets/Image/giamsoc.jpg" alt="">
                    </div>
                    <div class="productf-name">Lốc gió</div>
                    <div class="productf-price">Giá : 330.000Vnd</div>
                    <div class="productf-buttom">
                        <div class="productf-dis-favorite">Bỏ yêu thích</div>
                        <div class="productf-detail">Xem chi tiết</div>
                        <router-link to="/cart" class="productf-add-cart">
                            <div class="">Thêm vào giỏ hàng</div>
                        </router-link>
                    </div>
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

export default {
    /**
         * Tên component
         */
    name: 'FavoriteProduct',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink },
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
@import url(../../css/productfavorite.css);</style>