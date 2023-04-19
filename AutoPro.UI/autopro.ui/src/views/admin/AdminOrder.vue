<template>
    <div class="admin-content">
        <AdminLineLink name="Đơn hàng"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm đơn hàng"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addOrder">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách đơn hàng
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 150px;">Mã đơn hàng</th>
                        <th style="width: 100px;">Ngày tạo</th>
                        <th style="width: 350px;">Sản phẩm</th>
                        <th style="width: 150px;">Giá</th>
                        <th style="width: 100px;">Số lượng</th>
                        <th style="width: 200px;">Tổng tiền</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px;">1</td>
                        <td>user1</td>
                        <td>12345678</td>
                        <td>Phạm Đức Đăng</td>
                        <td>17/03/2001</td>
                        <td>Nam</td>
                        <td>Nam Định</td>
                        <td>
                            <div class="tbmethods">
                                <button>Sửa</button>
                                <button style="margin-left: 10px;">Xóa</button>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="see-more" style="margin-top: 10px;">Xem thêm</div>
        </div>
        <AdminOrderDetail v-if="showPopup" @onClose="showPopup = false"></AdminOrderDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import AdminOrderDetail from './AdminOrderDetail.vue';
import MInput from '@/components/MInput.vue';
export default {
    /**
           * Tên component
           */
    name: 'AdminOrder',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink, MInput, AdminOrderDetail },
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
        addOrder() {
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
@import url(../../css/admin/adminorder.css);
</style>