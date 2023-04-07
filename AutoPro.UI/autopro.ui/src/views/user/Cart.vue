<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Giỏ hàng"></TheLineLink>
            <table class="m-table">
                <thead>
                    <tr>
                        <th style="min-width: 50px;padding-left: 16px;">
                            <input type="checkbox">
                        </th>
                        <th style="min-width: 300px;">Sản phẩm</th>
                        <th style="min-width: 200px;">Đơn giá</th>
                        <th style="min-width: 100px;">Số lượng</th>
                        <th style="min-width: 200px;">Thành tiền</th>
                        <th style="min-width: 100px;">Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="min-width: 50px; padding-left: 16px;">
                            <input type="checkbox">
                        </td>
                        <td style="min-width: 300px;">
                            <div class="product-cart">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                                <div class="product-cart-name">Giảm sóc anjfca sjansjkcn asjcnajns dlkacnka nsdckansl dkcnsk
                                    dcnckja
                                </div>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 150px;">
                            <div class="number">
                                <i class="fa-solid fa-minus"></i>
                                <MInput style="width: 50px;border-radius: 0px;"></MInput>
                                <i class="fa-solid fa-plus"></i>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 100px; cursor: pointer;">
                            <div class="cart-method">Xóa</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; padding-left: 16px;">
                            <input type="checkbox">
                        </td>
                        <td style="min-width: 300px;">
                            <div class="product-cart">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                                <div class="product-cart-name">Giảm sóc anjfca sjansjkcn asjcnajns dlkacnka nsdckansl dkcnsk
                                    dcnckja
                                </div>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 150px;">
                            <div class="number">
                                <i class="fa-solid fa-minus"></i>
                                <MInput style="width: 50px;border-radius: 0px;"></MInput>
                                <i class="fa-solid fa-plus"></i>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 100px; cursor: pointer;">
                            <div class="cart-method">Xóa</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; padding-left: 16px;">
                            <input type="checkbox">
                        </td>
                        <td style="min-width: 300px;">
                            <div class="product-cart">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                                <div class="product-cart-name">Giảm sóc anjfca sjansjkcn asjcnajns dlkacnka nsdckansl dkcnsk
                                    dcnckja
                                </div>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 150px;">
                            <div class="number">
                                <i class="fa-solid fa-minus"></i>
                                <MInput style="width: 50px;border-radius: 0px;"></MInput>
                                <i class="fa-solid fa-plus"></i>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 100px; cursor: pointer;">
                            <div class="cart-method">Xóa</div>
                        </td>
                    </tr>
                    <tr>
                        <td style="min-width: 50px; padding-left: 16px;">
                            <input type="checkbox">
                        </td>
                        <td style="min-width: 300px;">
                            <div class="product-cart">
                                <img src="../../assets/Image/giamsoc.jpg" alt="">
                                <div class="product-cart-name">Giảm sóc anjfca sjansjkcn asjcnajns dlkacnka nsdckansl dkcnsk
                                    dcnckja
                                </div>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 150px;">
                            <div class="number">
                                <i class="fa-solid fa-minus"></i>
                                <MInput style="width: 50px;border-radius: 0px;"></MInput>
                                <i class="fa-solid fa-plus"></i>
                            </div>
                        </td>
                        <td style="min-width: 150px;">
                            200.000 vnd
                        </td>
                        <td style="min-width: 100px; cursor: pointer;">
                            <div class="cart-method">Xóa</div>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="pay">
            <div class="total-pay">
                Tổng thanh toán : 100.000 vnd
            </div>
            <router-link to="/purchase" class="purchase"><button>Mua hàng</button></router-link>
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
    name: 'Cart',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, MInput, TheFooter, TheLineLink },
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
@import url(../../css/cart.css);
</style>