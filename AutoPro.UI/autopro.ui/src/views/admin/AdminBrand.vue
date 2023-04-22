<template>
    <div class="admin-content">
        <AdminLineLink name="Nhãn hàng"></AdminLineLink>
        <div class="table-admin">
            <div class="table-toolbar">
                <div class="search-toolbar">
                    <MInput
                        styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        placeholder="Tìm kiếm nhãn hàng" v-model="textSearch" ref="inputSearch"></MInput>
                    <button @click="search">Tìm kiếm</button>
                </div>
                <div class="add-toolbar">
                    <button @click="addBrand">Thêm mới</button>
                    <div class="refresh" @click="refresh"><i class="fa-solid fa-rotate"></i></div>
                </div>
            </div>
            <div class="list-name-table">
                Danh sách nhãn hàng
                <!-- <div>
                    <MSelectBoxDown :data="[
                            { feildShow: 'Ngày tạo', feildValue: 'tb.createdDate ASC' },
                            { feildShow: 'Ngày tạo gần nhất', feildValue: 'tb.createdDate DESC' },
                            { feildShow: 'Ngày sửa', feildValue: 'tb.modifiedDate ASC' },
                            { feildShow: 'Ngày sửa gần nhất', feildValue: 'tb.modifiedDate DESC' },
                        ]" v-model="orderBy"></MSelectBoxDown>
                </div> -->
            </div>
            <table>
                <thead>
                    <tr>
                        <th style="width: 50px;padding-left: 10px;">STT</th>
                        <th style="width: 150px;">Mã nhãn hàng</th>
                        <th style="width: 150px;">Tên nhãn hàng</th>
                        <th style="width: 150px;">Hình ảnh</th>
                        <th style="width: 350px;">Mô tả</th>
                        <th style="width: 150px;">Ngày tạo</th>
                        <th style="width: 150px;">Ngày sửa</th>
                        <th>Thao tác</th>
                    </tr>
                </thead>
                <tbody>
                    <tr v-for="(item, index) in dataBrand" :key="index" @click="trClick(item.brandID)"
                        @dblclick="rowOnDblClick(item)" :class="{
                                'row-selected': rowSelected == item.brandID,
                            }">
                        <td style="padding-left: 10px;">{{ index + 1 }}</td>
                        <td>{{ item.brandCode }}</td>
                        <td>{{ item.brandName }}</td>
                        <td><img :src="item.image" alt="" style="width: 100px;height: 100px;"></td>
                        <td>{{ item.description }}</td>
                        <td>{{ formatDate(item.createdDate) }}</td>
                        <td>{{ formatDate(item.modifiedDate) }}</td>
                        <td>
                            <div class="tbmethods" @click="deleteItem(item)">
                                <button style="margin-left: 10px;">Xóa</button>
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
        <AdminBrandDetail v-if="showPopup" @onClose="showPopup = false" :id="id" :type="type" @success="success">
        </AdminBrandDetail>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>

<script>
import AdminLineLink from '@/layout/AdminLineLink.vue';
import MInput from '@/components/MInput.vue';
import AdminBrandDetail from './AdminBrandDetail.vue';
import Resource from '../../js/gResource';
import axios from 'axios';
import ApiBrand from '../../js/apiBrand';
import { formatDate } from '@/js/gCommon'
import MLoading from '@/components/MLoading.vue';
import { getStorage, ref, deleteObject } from "firebase/storage";
import MCombobox from '@/components/MCombobox.vue';
// import MSelectBoxDown from '@/components/MSelectBoxDown.vue';
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
    components: { AdminLineLink, MInput, AdminBrandDetail, MLoading, MCombobox },
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
            dataBrand: {},
            rowSelected: -1,
            reloadTable: false,
            showLoading: false,
            textSearch: "",
            pageSize: 10,
            pageNumber: 1,
            orderBy: 'tb.modifiedDate DESC',
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

        addBrand() {
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
                this.id = data.brandID;
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

            axios.delete(ApiBrand.deleteBrandByID(data.brandID))
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
                axios.get(ApiBrand.filterBrand(this.textSearch, this.pageSize, this.pageNumber))
                    .then((res) => {
                        if (res.status == 200) {
                            if (res.data.totalRecord > 0) {
                                this.showLoading = false;
                                this.noData = false;
                                this.dataBrand = res.data.data;
                                this.showSeeMore = true;
                                // console.log(res);
                            } else {
                                this.showLoading = false;
                                this.noData = true;
                                this.dataBrand = null;
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
        orderBy(newVal) {
            // this.orderBy = newVal;
            // console.log(newVal);
            this.filterAndPaging();
        }
    }
}
</script>

<style>
@import url(../../css/admin/adminbrand.css);
</style>