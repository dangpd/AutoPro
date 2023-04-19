<template>
    <div class="admin-content">
        <AdminLineLink name="Nhãn hàng"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm nhãn hàng"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addBrand">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách nhãn hàng
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 150px;">Mã nhãn hàng</th>
                        <th style="width: 150px;">Tên nhãn hàng</th>
                        <th style="width: 300px;">Hình ảnh</th>
                        <th style="width: 300px;">Mô tả</th>
                        <th style="width: 150px;">Ngày tạo</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px;">1</td>
                        <td>NH1</td>
                        <td>Toyata</td>
                        <td><img src="" alt=""></td>
                        <td>Mô tả</td>
                        <td>Ngày tạo</td>
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
        <AdminBrandDetail v-if="showPopup" @onClose="showPopup = false"></AdminBrandDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
import AdminBrandDetail from './AdminBrandDetail.vue';
export default {
    /**
           * Tên component
           */
    name: 'AdminBrand',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink, MInput, AdminBrandDetail },
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
        addBrand() {
            this.showPopup = true
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
@import url(../../css/admin/adminbrand.css);
</style>