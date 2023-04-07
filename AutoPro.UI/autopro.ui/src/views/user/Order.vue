<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Đơn hàng"></TheLineLink>
            <div class="list-product-order">
                <div class="title-product-order">ĐƠN HÀNG CỦA BẠN</div>
                <table class="m-table-order">
                    <thead>
                        <tr>
                            <th style="min-width: 200px;padding-left:10px">Sản phẩm</th>
                            <th style="min-width: 300px;">Thông tin sản phẩm</th>
                            <th style="min-width: 200px;">Đơn giá</th>
                            <th style="min-width: 100px;">Số lượng</th>
                            <th style="min-width: 200px;">Thành tiền</th>
                            <th style="min-width: 200px;">Trạng thái</th>
                            <th style="min-width: 100px;">Thao tác</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <div class="product-order-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                </div>
                            </td>
                            <td>
                                <div class="product-order-name">
                                    Giamr soavcakj sdkcjnsan sdfjkhcsiud sakdjfhcjks
                                </div>
                            </td>
                            <td>
                                <div class="product-order-price">
                                    200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-amount">
                                    * 1
                                </div>
                            </td>
                            <td>
                                <div class="product-order-totalmoney">
                                    = 200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-status">
                                    Đang xử lí
                                </div>
                            </td>
                            <td>
                                <div class="product-order-method">
                                    Hủy
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="product-order-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                </div>
                            </td>
                            <td>
                                <div class="product-order-name">
                                    Giamr soavcakj sdkcjnsan sdfjkhcsiud sakdjfhcjks
                                </div>
                            </td>
                            <td>
                                <div class="product-order-price">
                                    200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-amount">
                                    * 1
                                </div>
                            </td>
                            <td>
                                <div class="product-order-totalmoney">
                                    = 200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-status">
                                    Đang xử lí
                                </div>
                            </td>
                            <td>
                                <div class="product-order-method">
                                    Hủy
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="product-order-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                </div>
                            </td>
                            <td>
                                <div class="product-order-name">
                                    Giamr soavcakj sdkcjnsan sdfjkhcsiud sakdjfhcjks
                                </div>
                            </td>
                            <td>
                                <div class="product-order-price">
                                    200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-amount">
                                    * 1
                                </div>
                            </td>
                            <td>
                                <div class="product-order-totalmoney">
                                    = 200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-status">
                                    Đang xử lí
                                </div>
                            </td>
                            <td>
                                <div class="product-order-method">
                                    Hủy
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div class="product-order-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                </div>
                            </td>
                            <td>
                                <div class="product-order-name">
                                    Giamr soavcakj sdkcjnsan sdfjkhcsiud sakdjfhcjks
                                </div>
                            </td>
                            <td>
                                <div class="product-order-price">
                                    200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-amount">
                                    * 1
                                </div>
                            </td>
                            <td>
                                <div class="product-order-totalmoney">
                                    = 200.000 vnd
                                </div>
                            </td>
                            <td>
                                <div class="product-order-status">
                                    Đang xử lí
                                </div>
                            </td>
                            <td>
                                <div class="product-order-method">
                                    Hủy
                                </div>
                            </td>
                        </tr>
                    </tbody>
                </table>
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
    name: 'Order',
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
@import url(../../css/order.css);
</style>