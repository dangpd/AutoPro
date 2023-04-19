<template>
    <div class="admin-content">
        <AdminLineLink name="Tin tức"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm tin tức"></MInput>
                    <button>Tìm kiếm</button>
                </div>
                <div class="add-toolbar" @click="addNews">
                    <button>Thêm mới</button>
                </div>
            </div>
            <table>
                <div class="list-name-table">
                    Danh sách tin tức
                </div>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 250px;">Tiêu đề tin tức</th>
                        <th style="width: 100px;">Ngày tạo</th>
                        <th style="width: 250px;">Nội dung ngắn</th>
                        <th style="width: 450px;">Nội dung chính</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr>
                        <td style="padding-left: 10px;">1</td>
                        <td>Tiêu đề</td>
                        <td>Ngày tạo</td>
                        <td>Nội dung ngắn</td>
                        <td>Nội dung</td>
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
        <AdminNewsDetail v-if="showPopup" @onClose="showPopup = false"></AdminNewsDetail>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '../../components/MInput.vue';
import AdminNewsDetail from './AdminNewsDetail.vue';

export default {
    /**
           * Tên component
           */
    name: 'AdminNews',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { AdminLineLink, MInput, AdminNewsDetail },
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
        addNews() {
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
@import url(../../css/admin/adminnews.css);
</style>