<template>
  <div>
    <TheHeader></TheHeader>
    <TheNavbar></TheNavbar>
    <div class="content">
      <TheLineLink name="Đơn hàng"></TheLineLink>
      <div class="list-product-order">
        <div
          class="title-product-order"
          style="display: flex; align-items: center; margin-bottom: 10px"
        >
          <div>ĐƠN HÀNG CỦA BẠN</div>
          <!-- <router-link to="/orderplaced" style="cursor: pointer;">
            ĐƠN HÀNG ĐÃ ĐẶT
          </router-link> -->
          <div style="display: flex; align-items: center">
            Sắp xếp theo
            <MSelectBoxDown
              :data="[
                { feildShow: 'Tất cả đơn hàng', feildValue: 4 },
                { feildShow: 'Đơn hàng thành công', feildValue: 1 },
                { feildShow: 'Đơn hàng bị hủy', feildValue: 3 },
                { feildShow: 'Đơn hàng đang chờ xử lí', feildValue: 2 },
              ]"
              v-model="orderBy"
            ></MSelectBoxDown>
          </div>
        </div>
        <table class="m-table-order">
          <thead>
            <tr>
              <th style="width: 50px; padding-left: 10px">STT</th>
              <th style="width: 100px">Mã đơn hàng</th>
              <th style="width: 100px">Ngày tạo</th>
              <th style="width: 100px">Người nhận</th>
              <th style="width: 250px">Địa chỉ</th>
              <th style="width: 100px">Tổng tiền</th>
              <th style="width: 200px">Hình thức thanh toán</th>
              <th style="width: 170px">Trạng thái thanh toán</th>
              <th style="width: 150px">Trạng thái đơn hàng</th>
            </tr>
          </thead>
          <tbody style="line-height: 40px">
            <tr
              v-for="(item, index) in filterOrders"
              :key="index"
              @click="trClick(item.OrderID)"
              @dblclick="rowOnDblClick(item)"
              :class="{ 'row-selected': rowSelected == item.OrderID }"
            >
              <td style="padding-left: 10px">{{ index + 1 }}</td>
              <td>{{ item.OrderCode }}</td>
              <td>{{ formatDate(item.OrderDate) }}</td>
              <td>{{ item.FullName }}</td>
              <td>{{ item.Address }}</td>
              <td>{{ formatMoney(item.totalAmount) }}</td>
              <td>{{ item.CheckOutTypeName }}</td>
              <td>{{ item.CheckOutStatusName }}</td>
              <td>{{ item.StatusOrdersName }}</td>
              <!-- <td>
                <div class="product-order-method" v-show="item.StatusOrders == 2" @click="questionCancelItem(item)">
                  <div class="cancel-product-order">Hủy</div>
                </div>
              </td> -->
              <!-- <td>
                <div class="product-order-method" v-show="item.StatusOrders == 1" @click="writeComment()">
                  <div class="cancel-product-order">Đánh giá</div>
                </div>
              </td> -->
            </tr>
          </tbody>
        </table>
      </div>
    </div>
    <TheFooter></TheFooter>
    <MLoading v-if="showLoading"></MLoading>
    <OrderDetail
      v-if="showPopup"
      @onClose="showPopup = false"
      :id="id"
      :type="type"
      :statusOrder="statusOrder"
      :reloadDetail="reloadOrderDetail"
      @success="success"
      @showProductComment="showProductComment"
      @updateReload="updateReload"
    ></OrderDetail>
    <ProductComment
      v-if="showComment"
      @onClose="showComment = false"
      @updateOrderDetailProduct="updateOrderDetailProduct"
      :idProduct="idProductComment"
      :idOrder="idOrderComment"
      :idOrderDetail="idOrderDetailComment"
    ></ProductComment>
  </div>
</template>

<script>
import TheFooter from "@/layout/TheFooter.vue";
import TheHeader from "@/layout/TheHeader.vue";
import TheLineLink from "@/layout/TheLineLink.vue";
import TheNavbar from "@/layout/TheNavbar.vue";
import axios from "axios";
import ApiOrder from "../../js/apiOrder";
import { formatDate, formatMoney } from "@/js/gCommon";
import MLoading from "@/components/MLoading.vue";
import Resource from "../../js/gResource";
import OrderDetail from "./OrderDetail.vue";
import MSelectBoxDown from "@/components/MSelectBoxDown.vue";
import ProductComment from "./ProductComment.vue";

export default {
  /**
   * Tên component
   */
  name: "Order",
  /**
   * Hứng nhận
   */
  props: [""],
  /**
   * Component được sử dụng
   */
  components: {
    TheHeader,
    TheNavbar,
    TheFooter,
    TheLineLink,
    MLoading,
    OrderDetail,
    MSelectBoxDown,
    ProductComment,
  },
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
      dataOrder: [],
      showLoading: false,
      type: "",
      showPopup: false,
      noData: false,
      id: "",
      statusOrder: "",
      rowSelected: -1,
      reloadTable: false,
      customer: {},
      orderBy: 4,
      // showComment: false,
      showComment: false,
      idProductComment: "",
      idOrderComment: "",
      idOrderDetailComment: "",
      reloadOrderDetail: false,
    };
  },
  /**
   * Phương thức
   */
  methods: {
    questionSaveItem(item) {
      let text = `Bạn có muốn hủy đơn hàng "${item.OrderCode}" không không ?`;
      if (confirm(text) == true) {
        this.cancelOrderDetail(item);
      }
    },

    prepareBeforeHandle() {
      this.customer["orderCode"] = this.item.OrderCode;
      (this.customer["orderDate"] = this.item.OrderDate),
        (this.customer["idUser"] = this.item.IdUser);
      this.customer["fullName"] = this.item.FullName;
      this.customer["address"] = this.item.Address;
      this.customer["phoneNumber"] = this.item.PhoneNumber;
      this.customer["description"] = this.item.Description;
      this.customer["totalAmount"] = this.item.TotalAmount;
      this.customer["checkOutTypeID"] = this.item.CheckOutTypeID; // Thanh toán tại nhà
      this.customer["CheckOutStatusID"] = this.item.CheckOutStatusID; // Chưa thanh toán
      // Xử lý danh sách các hàng hóa mua
    },

    cancelOrderDetail(item) {
      const me = this;
      this.prepareBeforeHandle(item);
      this.customer["StatusOrders"] = 3; // chờ tiếp nhận
      let orderParam = {
        order: JSON.stringify(this.customer),
        orderdetail: JSON.stringify(this.orderDetail),
      };
      console.log(this.customer);
      console.log(this.orderDetail);
      console.log(orderParam);
      // Xác nhận đơn hàng
      axios.post(ApiOrder.updateOrderDetail(), orderParam).then((res) => {
        if (res.status === 200) {
          alert("Hủy đơn hàng thành công");
          this.$emit("onClose");
        } else {
          alert("Hủy đơn hàng thất bại");
          this.$emit("onClose");
        }
      });
    },

    formatMoney(moeny) {
      return formatMoney(moeny);
    },
    rowOnDblClick(data) {
      try {
        // console.log(data.OrderID);
        this.showPopup = true;
        this.id = data.OrderID;
        this.statusOrder = data.StatusOrders;
        this.type = Resource.FormAdminType.Update;
      } catch (error) {
        console.log(error);
      }
    },
    trClick(idRow) {
      this.rowSelected = idRow;
    },
    formatDate(datetime) {
      try {
        return formatDate(datetime);
      } catch (error) {
        console.log(error);
      }
    },
    success() {
      this.getOrderByUserID();
      this.reloadTable = false;
    },

    getOrderByUserID() {
      this.showLoading = true;
      let id = localStorage.getItem("UserID");
      setTimeout(() => {
        axios.get(ApiOrder.getByUserID(id)).then((res) => {
          this.showLoading = false;
          this.dataOrder = res.data;
          // console.log(this.dataOrder);
          // console.log(res);
        });
      }, 300);
    },

    showProductComment(data) {
      // console.log('data',data);
      this.showComment = true;
      this.idProductComment = data.productID;
      this.idOrderComment = data.orderID;
      this.idOrderDetailComment = data.orderDetailID;
    },

    updateOrderDetailProduct() {
      // this.$emit("updateOrderDetail");
      this.reloadOrderDetail = true;
    },

    updateReload(){
      this.reloadOrderDetail = false;
    }
  },
  created() {
    let id = localStorage.getItem("UserID");
    if (!id) {
      alert("Bạn cần đăng nhập để sử dụng tính năng này!");
      this.$router.push("/account/sign-up");
    } else {
      this.getOrderByUserID();
    }
  },
  /**
   * Theo dõi sự thay đổi
   */
  watch: {
    orderBy(newVal) {
      this.orderBy = newVal;
      console.log(newVal);
    },

    reloadOrderDetail(newVal) {
      console.log(newVal);
      this.reloadOrderDetail = newVal;
    },
  },
  computed: {
    filterOrders: function () {
      return this.dataOrder.filter((order) => {
        if (this.orderBy === 4) {
          return this.dataOrder;
        }
        return order.StatusOrders === this.orderBy;
      });
    },
  },
};
</script>

<style>
@import url(../../css/order.css);
</style>