<template>
    <div class="admin-content">
        <AdminLineLink name="Tin tức"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput v-model="textSearch" ref="inputSearch"
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm tin tức"></MInput>
                    <button @click="search">Tìm kiếm</button>
                </div>
                <div class="add-toolbar">
                    <button @click="addNews">Thêm mới</button>
                    <div class="refresh" @click="refresh"><i class="fa-solid fa-rotate"></i></div>
                </div>
            </div>
            <div class="list-name-table">
                Danh sách tin tức
            </div>
            <table>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 250px;">Tiêu đề tin tức</th>
                        <th style="width: 100px;">Ngày tạo</th>
                        <th style="width: 130px;">Hình ảnh</th>
                        <th style="width: 200px;">Nội dung ngắn</th>
                        <th style="width: 400px;">Nội dung chính</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item, index) in dataNews" :key="index" @click="trClick(item.newsID)"
                        @dblclick="rowOnDblClick(item)" :class="{
                                'row-selected': rowSelected == item.newsID,
                            }">
                        <td style="padding-left: 10px;text-align:center">{{ index + 1 }}</td>
                        <td>{{ item.newsTitle }}</td>
                        <td>{{ formatDate(item.newsDate) }}</td>
                        <td><img :src="item.image" alt="" style="width: 100px;height: 100px;"></td>
                        <td>{{ item.contentShorted }} </td>
                        <td>{{ item.content }}</td>
                        <td>
                            <div class="tbmethods">
                                <button style="margin-left: 10px;" @click="deleteItem(item)">Xóa</button>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div class="nodata" v-show="noData">
                <img src="../../assets/Image/Nodata.jpg" alt="">
            </div>
            <div class="see-more" style="margin-top: 10px;" @click="seeMore" v-show="showSeeMore">Xem thêm</div>
        </div>
        <AdminNewsDetail v-if="showPopup" @onClose="showPopup = false" :id="id" :type="type" @success="success">
        </AdminNewsDetail>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '../../components/MInput.vue';
import AdminNewsDetail from './AdminNewsDetail.vue';
import Resource from '../../js/gResource';
import axios from 'axios';
import ApiBrand from '../../js/apiBrand';
import { formatDate } from '@/js/gCommon'
import MLoading from '@/components/MLoading.vue';
import { getStorage, ref, deleteObject } from "firebase/storage";
import ApiNews from '../../js/apiNews';
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
    components: { AdminLineLink, MInput, AdminNewsDetail, MLoading },
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
            noData: false,
            id: '',
            type: '',
            dataNews: {},
            rowSelected: -1,
            reloadTable: false,
            showLoading: false,
            textSearch: "",
            pageSize: 10,
            pageNumber: 1,
            showSeeMore: false,
        }
    },
    /**
     * Phương thức
     */
    methods: {
        trClick(idRow) {
            this.rowSelected = idRow;
        },

        addNews() {
            this.showPopup = true;
            this.id = null;
            this.type = Resource.FormAdminType.Add;
        },

        refresh() {
            this.textSearch = '';
            this.pageSize = 10;
            this.pageNumber = 1;
            this.filterAndPaging();
        },

        rowOnDblClick(data) {
            try {
                this.showPopup = true;
                this.id = data.newsID;
                this.type = Resource.FormAdminType.Update;
            } catch (error) {
                console.log(error);
            }
        },

        deleteItem(data) {
            if (data.image != null) {
                const storage = getStorage();

                // Create a reference to the file to delete
                const desertRef = ref(storage, data.image);

                // Delete the file
                deleteObject(desertRef).then(() => {
                    console.log("xóa thành công");
                }).catch((error) => {
                    console.log("Xóa thất bại");
                });
            }

            axios.delete(ApiNews.deleteNewsByID(data.newsID))
                .then((res) => {
                    if (res.status == 200) {
                        this.filterAndPaging();
                    }
                })
        },

        formatDate(datetime) {
            try {
                return formatDate(datetime);
            } catch (error) {
                console.log(error);
            }
        },

        filterAndPaging() {
            this.showLoading = true;
            setTimeout(() => {
                axios.get(ApiNews.filterNews(this.textSearch, this.pageSize, this.pageNumber))
                    .then((res) => {
                        if (res.status == 200) {
                            if (res.data.totalRecord > 0) {
                                this.showLoading = false;
                                this.noData = false;
                                this.dataNews = res.data.data;
                                this.showSeeMore = true;

                                // console.log(res);
                            } else {
                                this.showLoading = false;
                                this.noData = true;
                                this.dataNews = null;
                                this.showSeeMore = false;

                            }
                        }
                    })
            }, 1000)
        },

        success() {
            this.filterAndPaging();
            this.reloadTable = false;
        },

        search() {
            this.textSearch = this.$refs.inputSearch.modelValue;
            this.pageSize = 10;
            this.pageNumber = 1;
            this.filterAndPaging();
        },

        seeMore() {
            this.textSearch = this.$refs.inputSearch.value;
            this.pageSize = this.pageSize + 10;
            this.pageNumber = 1;
            this.filterAndPaging();
        }
    },
    created() {
        this.filterAndPaging();
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