<template>
  <div class="admin-content">
    <AdminLineLink name="Tài khoản"></AdminLineLink>
    <div class="table-admin">
      <div class="table-toolbar">
        <div class="search-toolbar">
          <MInput v-model="textSearch" ref="inputSearch"
            styleInput="width:400px; height:36px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
            placeholder="Tìm kiếm tài khoản"></MInput>
          <button @click="search">Tìm kiếm</button>
        </div>
        <div class="add-toolbar">
          <button @click="addAccount">Thêm mới</button>
          <div class="refresh" @click="refresh"><i class="fa-solid fa-rotate"></i></div>
        </div>
      </div>
      <div class="list-name-table">Danh sách tài khoản</div>
      <table>
        <thead>
          <tr>
            <th style="width: 50px; padding-left: 10px;">STT</th>
            <th style="width: 150px">Tên tài khoản</th>
            <th style="width: 150px">Mật khẩu</th>
            <th style="width: 150px">Họ và tên</th>
            <th style="width: 100px">Ngày sinh</th>
            <th style="width: 100px">Giới tính</th>
            <th style="width: 200px">Địa chỉ</th>
            <th style="width: 200px">Email</th>
            <th>Thao tác</th>
          </tr>
        </thead>
        <tbody v-for="(item, index) in dataUser" :key="index" @click="trClick(item.userID)"
          @dblclick="rowOnDblClick(item)" :class="{
              'row-selected': rowSelected == item.userID,
            }">
          <tr>
            <td style="padding-left: 10px;">{{ index + 1 }}</td>
            <td>{{ item.account }}</td>
            <td>{{ item.password }}</td>
            <td>{{ item.fullName }}</td>
            <td>{{ formatDate(item.dateOfBirth) }}</td>
            <td>{{ formatGender(item.gender) }}</td>
            <td>{{ item.address }}</td>
            <td>{{ item.email }}</td>
            <td>
              <div class="tbmethods">
                <button style="margin-left: 10px" @click="deleteItem(item)">Xóa</button>
              </div>
            </td>
          </tr>
        </tbody>
      </table>
      <div class="nodata" v-show="noData">
        <img src="../../assets/Image/Nodata.jpg" alt="">
      </div>
      <div class="see-more" style="margin-top: 10px" @click="seeMore" v-show="showSeeMore">Xem thêm</div>
    </div>
    <AdminAccountDetail v-if="showPopup" @onClose="showPopup = false" :id="id" :type="type" @success="success">
    </AdminAccountDetail>
    <MLoading v-if="showLoading"></MLoading>
  </div>
</template>

<script>
import MInput from "@/components/MInput.vue";
import AdminLineLink from "@/layout/AdminLineLink.vue";
import AdminAccountDetail from "./AdminAccountDetail.vue";
import Resource from '../../js/gResource';
import axios from 'axios';
import ApiBrand from '../../js/apiBrand';
import { formatDate, formatGender } from '@/js/gCommon'
import MLoading from '@/components/MLoading.vue';
import { getStorage, ref, deleteObject } from "firebase/storage";
import ApiUser from '../../js/apiUser';
export default {
  /**
   * Tên component
   */
  name: "AdminAccount",
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: { AdminLineLink, MInput, AdminAccountDetail, MLoading },
  /**
   * Emit sự thay đổi
   */
  emits: [""],
  directives: {},
  /**
   * Data
   */
  data() {
    return {
      showPopup: false,
      noData: false,
      id: '',
      type: '',
      dataUser: {},
      rowSelected: -1,
      reloadTable: false,
      showLoading: false,
      textSearch: "",
      pageSize: 10,
      pageNumber: 1,
      showSeeMore: false,
    };
  },
  /**
   * Phương thức
   */
  methods: {
    trClick(idRow) {
      this.rowSelected = idRow;
    },

    addAccount() {
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
        this.id = data.userID;
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

      axios.delete(ApiBrand.deleteBrandByID(data.userID))
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

    formatGender(gender) {
      return formatGender(gender);
    },

    filterAndPaging() {
      this.showLoading = true;
      setTimeout(() => {
        axios.get(ApiUser.filterUser(this.textSearch, this.pageSize, this.pageNumber))
          .then((res) => {
            if (res.status == 200) {
              if (res.data.totalRecord > 0) {
                this.showLoading = false;
                this.noData = false;
                this.dataUser = res.data.data;
                this.showSeeMore = true;
                // console.log(res);
              } else {
                this.showLoading = false;
                this.noData = true;
                this.showSeeMore = false;
                this.dataUser = null;
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
  watch: {},
};
</script>

<style>
@import url(../../css/admin/adminaccount.css);
</style>