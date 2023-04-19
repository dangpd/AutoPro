<template>
    <div class="admin-content">
        <AdminLineLink name="Liên hệ"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm liên hệ"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addContact">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách liên hệ
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 150px;">Người gửi</th>
                        <th style="width: 250px;">Email</th>
                        <th style="width: 150px;">Số điện thoại</th>
                        <th style="width: 500px;">Nội dung liên hệ</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px;">1</td>
                        <td>Người gửi 1</td>
                        <td>Email</td>
                        <td>1234567890</td>
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
        <AdminContactDetail v-if="showPopup" @onClose="showPopup = false"></AdminContactDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
import AdminContactDetail from './AdminContactDetail.vue';

export default {
    /**
           * Tên component
           */
    name: 'AdminContact',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink, MInput, AdminContactDetail },
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
        addContact() {
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
@import url(../../css/admin/admincontact.css);
</style>