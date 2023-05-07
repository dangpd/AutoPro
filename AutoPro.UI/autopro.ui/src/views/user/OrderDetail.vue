<template>
    <div class="aform-detail">
        <div class="aform-account">
            <div class="aform-title">
                <div class="aform-title-left">
                    {{ this.title }}
                </div>
                <div class="onClose" @click="onClose">
                    <i class="fa-regular fa-circle-xmark"></i>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Mã đơn hàng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.orderCode">
                    </MInput>
                </div>
                <div class="acol1">
                    <div class="acol1-text">
                        Người đặt :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.fullName">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol2">
                    <div class="acol2-text">
                        Ngày đặt :
                    </div>
                    <MDatePicker v-model="customer.orderDate"
                        styleVal="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MDatePicker>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Số điện thoại :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.phoneNumber">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol2-text">
                        Lưu ý của khách hàng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.description">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Phương thức thanh toán :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.checkOutTypeName">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Tình trạng thanh toán :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.checkoutStatusName">
                    </MInput>
                </div>
                <div class="acol1">
                    <div class="acol1-text">
                        Tình trạng đơn hàng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="customer.statusOrdersName">
                    </MInput>
                </div>
            </div>
            <div class="agroup1" style="margin:10px 0;">
                Danh sách sản phẩm đơn hàng
            </div>
            <table border="1" style="height: auto;" class="m-table-order">
                <thead style="line-height: 40px;">
                    <tr>
                        <th style="width: 100px;padding-left: 10px;">STT</th>
                        <th style="width: 200px;">Mã sản phẩm</th>
                        <th style="width: 400px;">Tên sản phẩm</th>
                        <th style="width: 250px;">Giá</th>
                        <th style="width: 200px;">Số lượng mua</th>
                        <th style="width: 300px;">Tổng tiền</th>
                    </tr>
                </thead>
                <tbody style="line-height: 36px;">
                    <tr v-for="(item, index) in orderDetail" :key="index" :class="{
                        'row-selected': rowSelected == item.productID
                    }" style="cursor: pointer;">
                        <td style="padding-left: 10px;">{{ index + 1 }}</td>
                        <td @click="detailProduct(item)">{{ item.productCode }}</td>
                        <td @click="detailProduct(item)">{{ item.productName }}</td>
                        <td @click="detailProduct(item)">{{ formatMoney(item.price) }}</td>
                        <td @click="detailProduct(item)">{{ item.quantitys }}</td>
                        <td @click="detailProduct(item)">{{ formatMoney(item.price * item.quantitys) }}</td>
                        <td>
                            <div class="product-order-method" v-show="statusOrder == 1"
                                @click="writeComment(item)">
                                <div class="cancel-product-order">Đánh giá</div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <div style="margin:20px 0;">Tổng tiền cần thanh toán: <b>{{ formatMoney(customer.totalAmount) }}</b></div>
            <div class="aformSave" v-show="processOrder">
                <!-- <button style="background-color: #019160;color: white;" @click="questionSaveItem">Duyệt đơn hàng</button> -->
                <button style="background-color: #BA031A;margin-left: 40px;color: white;" @click="questionCancelItem">Hủy
                    đơn
                    hàng</button>
            </div>
            <div class="aformSave" v-show="doneOrder">
                <button style="background-color: #019160;color: white;" @click="onClose">Đơn hàng đã được duyệt</button>
            </div>
            <div class="aformSave" v-show="cancelOrder">
                <button style="background-color: #BA031A;color: white;" @click="onClose">Đơn hàng đã bị hủy</button>
            </div>
        </div>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import ApiOrder from '../../js/apiOrder';
import MLoading from '@/components/MLoading.vue';
import axios from 'axios';
import Resource from '@/js/gResource';
import MDatePicker from '@/components/MDatePicker.vue';
import { formatMoney } from "@/js/gCommon"
export default {
    /**
     * Tên component
     */
    name: "OrderDetail",
    /**
     * Hứng nhận
     */
    props: ["id", "type", "statusOrder"],
    /**
     * Component được sử dụng
     */
    components: { MInput, MLoading, MDatePicker },
    /**
     * Emit sự thay đổi
     */
    emits: ["onClose", "success", "showProductComment"],
    directives: {},
    /**
     * Data
     */
    data() {
        return {
            orderDetail: {},
            customer: {},
            showLoading: false,
            title: '',
            processOrder: false,
            doneOrder: false,
            rowSelected: -1,
            cancelOrder: false,
        };
    },
    /**
     * Phương thức
     */
    methods: {
        detailProduct(data) {
            this.$router.push({ name: 'product', params: { id: data.productID } });
        },

        questionSaveItem(item) {
            let text = `Bạn có muốn duyệt đơn hàng này không không ?`;
            if (confirm(text) == true) {
                this.approveOrderDetail();
            } else {
                this.$emit("onClose");
            }
        },

        questionCancelItem(item) {
            let text = `Bạn có muốn hủy đơn hàng này không ?`;
            if (confirm(text) == true) {
                this.cancelOrderDetail();
            } else {
                this.$emit("onClose");
            }
        },

        onClose() {
            this.$emit("onClose");
        },

        formatMoney(money) {
            return formatMoney(money);
        },
        /**\
         * Chuẩn bị dữ liệu trước khi đặt hàng
         */
        prepareBeforeHandle() {
            this.customer["orderCode"] = this.customer.orderCode;
            this.customer["orderDate"] = this.customer.orderDate,
                this.customer["idUser"] = this.customer.idUser;
            this.customer["fullName"] = this.customer.fullName;
            this.customer["address"] = this.customer.address;
            this.customer["phoneNumber"] = this.customer.phoneNumber;
            this.customer["description"] = this.customer.description;
            this.customer["totalAmount"] = this.customer.totalAmount;
            this.customer["checkOutTypeID"] = this.customer.checkOutTypeID; // Thanh toán tại nhà
            this.customer["CheckOutStatusID"] = this.customer.CheckOutStatusID // Chưa thanh toán
            // Xử lý danh sách các hàng hóa mua
        },

        approveOrderDetail() {
            const me = this;
            this.prepareBeforeHandle();
            this.customer["statusOrders"] = 1; // chờ tiếp nhận
            let orderParam = {
                order: JSON.stringify(this.customer),
                orderdetail: JSON.stringify(this.orderDetail),
            };
            console.log(this.customer);
            console.log(this.orderDetail);
            console.log(orderParam);
            // Xác nhận đơn hàng
            axios.post(ApiOrder.updateOrderDetail(), orderParam)
                .then((res) => {
                    if (res.status === 200) {
                        alert("Đơn hàng đã được xác nhận");
                        this.$emit("success")
                        this.$emit("onClose");
                    } else {
                        alert("Xác nhận đơn hàng thất bại");
                        this.$emit("onClose");
                    }
                })
        },

        cancelOrderDetail() {
            const me = this;
            this.prepareBeforeHandle();
            this.customer["statusOrders"] = 3; // chờ tiếp nhận
            let orderParam = {
                order: JSON.stringify(this.customer),
                orderdetail: JSON.stringify(this.orderDetail),
            };
            console.log(this.customer);
            console.log(this.orderDetail);
            console.log(orderParam);
            // Xác nhận đơn hàng
            axios.post(ApiOrder.updateOrderDetail(), orderParam)
                .then((res) => {
                    if (res.status === 200) {
                        alert("Hủy đơn hàng thành công");
                        this.$emit("success")
                        this.$emit("onClose");
                        this.$toast.success("Hủy đơn hàng thành công")

                    } else {
                        alert("Hủy đơn hàng thất bại");
                        this.$toast.error("Hủy đơn hàng thất bại")
                        this.$emit("onClose");
                    }
                })
        },

        writeComment(data) {
            this.$emit("showProductComment", data);
        },

        onClose() {
            this.$emit("onClose")
        }
    },
    created() {
        if (this.id) {
            // Bật loadding
            this.showLoading = true;
            setTimeout(() => {
                this.title = Resource.TitleFormAdmin.updateOrderDetail;
                //Lấy dữ liệu
                axios.get(ApiOrder.getOrderDeatilByID(this.id))
                    .then((res) => {
                        // console.log(res);
                        this.showLoading = false;
                        this.customer = res.data.orders;
                        this.orderDetail = res.data.orderDetail;
                        if (this.statusOrder == 2) {
                            this.processOrder = true;
                            this.doneOrder = false;
                            this.cancelOrder = false;
                        } else if (this.statusOrder == 1) {
                            this.processOrder = false;
                            this.doneOrder = true;
                            this.cancelOrder = false;
                        } else if (this.statusOrder == 3) {
                            this.processOrder = false;
                            this.doneOrder = false;
                            this.cancelOrder = true;
                        }
                    })
            }, 500)
        } else {
            // this.title = Resource.TitleFormAdmin.AddAccount;
        }
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