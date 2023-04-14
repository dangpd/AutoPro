<template>
    <div class="admin-content">
        <AdminLineLink name="Danh mục sản phẩm"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;" placeholder="Tìm kiếm danh mục"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách danh mục
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 150px;">Tên tài khoản</th>
                        <th style="width: 100px;">Mật khẩu</th>
                        <th style="width: 150px;">Họ và tên</th>
                        <th style="width: 100px;">Ngày sinh</th>
                        <th style="width: 100px;">Giới tính</th>
                        <th style="width: 200px;">Địa chỉ</th>
                        <th style="width: 150px;">Email</th>
                        <th style="width: 100px;">Số điện thoại</th>
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
                        <td>phamducdang@gmail.com</td>
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
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
export default {
    /**
           * Tên component
           */
    name: 'AdminCategory',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink,MInput },
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
@import url(../../css/admin/admincategory.css);
</style>