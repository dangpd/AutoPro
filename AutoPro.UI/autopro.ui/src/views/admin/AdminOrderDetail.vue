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
                        v-model="orders.orderCode">
                    </MInput>
                </div>
                <div class="acol1">
                    <div class="acol1-text">
                        Người đặt :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="orders.fullName">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol2">
                    <div class="acol2-text">
                        Ngày đặt :
                    </div>
                    <MDatePicker v-model="orders.orderDate"
                        styleVal="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MDatePicker>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Số điện thoại :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="orders.phoneNumber">
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
                        v-model="orders.description">
                    </MInput>
                </div>
                <div class="acol2">
                    <div class="acol2-text">
                        Phương thức thanh toán :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="orders.checkOutTypeName">
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
                        v-model="orders.checkoutStatusName">
                    </MInput>
                </div>
                <div class="acol1">
                    <div class="acol1-text">
                        Tình trạng đơn hàng :
                    </div>
                    <MInput type="text"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                        v-model="orders.statusOrdersName">
                    </MInput>
                </div>
            </div>
            <div class="agroup1" style="margin:10px 0;">
                Danh sách sản phẩm đơn hàng
            </div>
            <table border="1" style="height: auto;">
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
                    <tr v-for="(item, index) in orderDetail" :key="index">
                        <td style="padding-left: 10px;">{{ index + 1 }}</td>
                        <td>{{ item.productCode }}</td>
                        <td>{{ item.productName }}</td>
                        <td>{{ formatMoney(item.price) }}</td>
                        <td>{{ item.quantitys }}</td>
                        <td>{{ formatMoney(item.price * item.quantitys) }}</td>
                    </tr>
                </tbody>
            </table>
            <div style="margin:20px 0;">Tổng tiền cần thanh toán: <b>{{ formatMoney(orders.totalAmount) }}</b></div>
            <div class="aformSave" v-show="processOrder">
                <button style="background-color: #019160;color: white;" @click="approveOrderDetail">Duyệt đơn hàng</button>
                <button style="background-color: #BA031A;margin-left: 40px;color: white;" @click="cancelOrderDetail">Hủy đơn
                    hàng</button>
            </div>
            <div class="aformSave" v-show="doneOrder">
                <button style="background-color: #019160;color: white;">Đơn hàng đã được duyệt</button>
            </div>
            <div class="aformSave" v-show="cancelOrder">
                <button style="background-color: #BA031A;color: white;">Đơn hàng đã bị hủy</button>
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
    name: "AdminOrderDetail",
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
    emits: ["onClose", "success"],
    directives: {},
    /**
     * Data
     */
    data() {
        return {
            orderDetail: {},
            orders: {},
            showLoading: false,
            title: '',
            processOrder: false,
            doneOrder: false,
            cancelOrder: false,
        };
    },
    /**
     * Phương thức
     */
    methods: {
        onClose() {
            this.$emit("onClose");
        },

        formatMoney(money) {
            return formatMoney(money);
        },

        async approveOrderDetail() {
            const me = this;
            this.prepareBeforeHandle();
            let orderParam = {
                order: JSON.stringify(this.orders),
                orderdetail: JSON.stringify(this.orderDetail),
            };
            console.log(orderParam);
            // if (this.type == Resource.FormAdminType.Add) {
            //     await axios.post(ApiContact.addContact(), this.contact)
            //         .then((res) => {
            //             if (res.status == 201) {
            //                 this.$emit("onClose");
            //                 this.$emit("success");
            //             }
            //         })
            //         .catch((err) => {
            //             console.log(err);
            //         })
            // }
        },

        cancelOrderDetail() {

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
                        console.log(res);
                        this.showLoading = false;
                        this.orders = res.data.orders;
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