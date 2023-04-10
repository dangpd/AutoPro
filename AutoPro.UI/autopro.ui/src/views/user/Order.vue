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
                            <th style="width: 120px;padding-left:10px">Mã đơn hàng</th>
                            <th style="width: 200px;">Sản phẩm</th>
                            <th style="width: 350px;">Thông tin sản phẩm</th>
                            <th style="width: 150px;">Ngày đặt</th>
                            <th style="width: 150px;">Thành tiền</th>
                            <th style="width: 150px;">Trạng thái</th>
                            <th style="width: 100px;">Thao tác</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>
                                <div class="product-order-code">
                                    DH01
                                </div>
                            </td>
                            <td>
                                <div class="product-order-image">
                                    <img src="../../assets/Image/giamsoc.jpg" alt="">
                                </div>
                            </td>
                            <td>
                                <div class="product-order-info">
                                    <div class="product-order-name">
                                        Tên sp: Giamr soavcakj sdk snfd sdfc sdf sfd cjnsan sdfjkhcsiud sakdjfhcjks
                                    </div>
                                    <div class="product-order-price">
                                        Giá : 200.000 vnd
                                    </div>
                                    <div class="product-order-amount">
                                        Số lượng * 1
                                    </div>
                                </div>
                            </td>
                            <td>
                                <div class="product-order-time">
                                    Ngày : 1/2/2023
                                </div>
                            </td>
                            <td>
                                <div class="product-order-totalmoney">
                                    200.000 vnd
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