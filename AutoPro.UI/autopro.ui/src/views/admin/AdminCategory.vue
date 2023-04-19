<template>
    <div class="admin-content">
        <AdminLineLink name="Danh mục sản phẩm"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm danh mục"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addCategory">
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
                        <th style="width: 150px;">Mã danh mục</th>
                        <th style="width: 250px;">Tên danh mục</th>
                        <th style="width: 500px;">Mô tả</th>
                        <th style="width: 150px;">Ngày tạo</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px;">1</td>
                        <td>DM1</td>
                        <td>Danh mục 1</td>
                        <td>Mô tả</td>
                        <td>17/03/2001</td>
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
        <AdminCategoryDetail v-if="showPopup" @onClose="showPopup = false"></AdminCategoryDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
import AdminCategoryDetail from './AdminCategoryDetail.vue';
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
    components: { AdminLineLink, MInput, AdminCategoryDetail },
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
        addCategory() {
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
@import url(../../css/admin/admincategory.css);
</style>