<template>
    <div class="admin-content">
        <AdminLineLink name="Sản phẩm"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm sản phẩm"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addProduct">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách sản phẩm
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 100px;">Mã sản phẩm</th>
                        <th style="width: 150px;">Tên sản phẩm</th>
                        <th style="width: 150px;">Giá</th>
                        <th style="width: 100px;">Nơi xuất xứ</th>
                        <th style="width: 100px;">Trạng thái</th>
                        <th style="width: 200px;">Hình ảnh</th>
                        <th style="width: 100px;">Số lượng</th>
                        <th style="width: 100px;">Mô tả</th>
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
                        <td>100</td>
                        <td>031245678</td>
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
        <AdminProductDetail v-if="showPopup" @onClose="showPopup = false"></AdminProductDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
import AdminProductDetail from './AdminProductDetail.vue';
export default {
    /**
           * Tên component
           */
    name: 'AdminProduct',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink, MInput, AdminProductDetail },
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
        addProduct() {
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
@import url(../../css/admin/adminproduct.css);
</style>