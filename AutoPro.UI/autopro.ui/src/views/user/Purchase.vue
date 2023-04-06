<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Đặt hàng"></TheLineLink>
            <div class="purcharse">
                <div class="information-user-order">
                    <div class="title-purcharse-user">
                        <h6>Thông tin khách hàng</h6>
                        <router-link to="/user/:id" class="user-update">Chỉnh sửa thông tin khách hàng</router-link>
                    </div>
                    <div class="content-purcharse-user">
                        <div class="purcharse-name">
                            <h6>Họ và tên: </h6>
                            <MInput styleInput="width:350px"></MInput>
                        </div>
                        <div class="purcharse-address">
                            <h6>Địa chỉ: </h6>
                            <MInput styleInput="width:350px"></MInput>
                        </div>
                        <div class="purcharse-phone-number">
                            <h6>Số điện toại: </h6>
                            <MInput styleInput="width:350px"></MInput>
                        </div>
                        <div class="purcharse-payment-methods">
                            <h6>Phương thức thanh toán</h6>
                            <input type="radio" id="method" value="Thanh toán tại nhà" />
                            <label for="method" style="padding-left: 8px;">Thanh toán tại nhà</label>
                        </div>
                    </div>
                </div>
                <div class="information-product">
                    <h6>Thông tin đơn hàng</h6>
                    <div class="list-purchase-product">
                        <div class="product-purchase">
                            <div class="product-purchase-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="product-purchase-name">
                                giảm sóc jnsadkjdvnkds skdnj asd asd sdfn skjdfnckjn sdhfn juhj
                            </div>
                            <div class="product-purchase-totalmoney">
                                1232.2sdf23 vnd
                            </div>
                        </div>
                        <div class="product-purchase">
                            <div class="product-purchase-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="product-purchase-name">
                                giảm sóc jnsadkjdvnkds skdnj asd asd sdfn skjdfnckjn sdhfn juhj
                            </div>
                            <div class="product-purchase-totalmoney">
                                1232.2sdf23 vnd
                            </div>
                        </div>
                        <div class="product-purchase">
                            <div class="product-purchase-image">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                            </div>
                            <div class="product-purchase-name">
                                giảm sóc jnsadkjdvnkds skdnj asd asd sdfn skjdfnckjn sdhfn juhj
                            </div>
                            <div class="product-purchase-totalmoney">
                                1232.2sdf23 vnd
                            </div>
                        </div>
                    </div>
                    <div class="total">
                        <div>Tổng cộng :</div>
                        <div>1 nvd</div>
                    </div>
                </div>
            </div>
            <router-link to="/order">
                <div class="order-purchase">
                    <button>Đặt hàng</button>
                </div>
            </router-link>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';

export default {
    /**
     * Tên component
     */
    name: 'Purchase',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput },
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
@import url(../../css/purcharse.css);
</style>