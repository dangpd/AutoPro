<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Đặt hàng"></TheLineLink>
            <div class="purcharse">
                <div class="information-user-order">
                    <div class="title-purcharse-user">
                        <h6>Thông tin khách hàng</h6>
                        <router-link to="/user/:id" class="user-update">Chỉnh sửa thông tin nhận hàng</router-link>
                    </div>
                    <div class="content-purcharse-user">
                        <div class="purcharse-name">
                            <h6>Họ và tên: </h6>
                            <input type="text" class="m-inputp" v-model="fullName"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-address">
                            <h6>Địa chỉ: </h6>
                            <input type="text" class="m-inputp" v-model="address"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-phone-number">
                            <h6>Số điện toại: </h6>
                            <input type="text" class="m-inputp" v-model="phoneNumber"
                                style="width: 350px;height: 30px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;">
                        </div>
                        <div class="purcharse-payment-methods">
                            <h6>Phương thức thanh toán</h6>
                            <MRadio :data="[
                                    { Gender: 'Thanh toán qua VNPay', GenderValue: 1 },
                                    { Gender: 'Thanh toán tại nhà', GenderValue: 2 },
                                ]" v-model="checkOutTypeID"></MRadio>
                        </div>
                        <div class="purcharse-phone-number">
                            <h6>Ghi chú</h6>
                            <textarea v-model="description"
                                style="width: 350px;height: 100px;padding-left: 10px;border-radius: 4px;border: 1px solid #bbb;word-break: break-word;margin-top: 70px;"></textarea>
                        </div>
                        <div style="position: absolute;bottom: 0;right: 40px;" v-if="showPayVnPay">
                            <button style="padding: 0 10px;border:1px solid #bbb;border-radius: 4px;">Đi tới thanh toán
                                VNPAY</button>
                        </div>
                    </div>
                </div>
                <div class="information-product">
                    <h6>Thông tin đơn hàng</h6>
                    <div class="list-purchase-product" v-for="(item, index) in listCart" :key="index"
                        @click="detailProduct(item)" style="cursor: pointer;" :class="{
                                'row-selected': rowSelected == item.productID
                            }">
                        <div class="product-purchase">
                            <div class="product-purchase-image">
                                <img :src="item.image" alt="">
                            </div>
                            <div class="product-purchase-name">
                                {{ item.productName }}
                                <br>
                                Giá sản phẩm: {{ formatMoney(item.price) }}
                                <br>
                                Số lượng*{{ item.quantitys }}
                            </div>
                            <div class="product-purchase-totalmoney">
                                {{ formatMoney(item.price * item.quantitys) }}
                                <div class="thungracdonhang" @click="deleteProdoctCart(item)">
                                    <img src="../../assets/Image/thungrac.png" alt="">
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="total">
                        <div>Tổng cộng: </div>
                        <div> {{ formatMoney(totalAmount) }}</div>
                    </div>
                </div>
            </div>
            <!-- <router-link to="/order"> -->
            <div class="order-purchase" @click="orderProduct">
                <button>Đặt hàng</button>
            </div>
            <!-- </router-link> -->
        </div>
        <TheFooter></TheFooter>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import { formatMoney } from '@/js/gCommon'
import TheNavbar from '@/layout/TheNavbar.vue';
import axios from 'axios';
import ApiUser from '../../js/apiUser';
import MLoading from '@/components/MLoading.vue';
import MRadio from '@/components/MRadio.vue';
import ApiOrder from '../../js/apiOrder';

export default {
    /**
     * Tên component
     */
    name: 'Purchase',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, TheLineLink, MInput, MLoading, MRadio },
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
            user: {},
            showPayVnPay: false,
            showLoading: false,
            customerInfo: {},
            orderDate: new Date(),
            deliveryDate: '',
            userID: '',
            fullName: '',
            address: '',
            phoneNumber: '',
            checkOutTypeID: 2,
            description: '',
            listCart: [],
            listOrderDetail: [],
        }
    },
    /**
     * Phương thức
     */
    methods: {
        formatMoney(menoy) {
            return formatMoney(menoy);
        },

        deleteProdoctCart(item) {
            let text = `Bạn có muỗn xóa sản phẩm "${item.productName}" khỏi đơn hàng không ?`;
            if (confirm(text) == true) {
                this.removeProduct(item);
            }
        },

        removeProduct(item) {
            this.$store.commit('removeCart', item);
        },

        validateBeforeSave(data) {
            /**
             * Kiểm tra dữ liệu trước khi lưu
             */
            this.$refs.form.validate();
            if (
                !this.validForm ||
                !dataSave ||
                (dataSave && Object.keys(dataSave).length === 0)
            ) {
                return false;
            }
            if (!this.radios) {
                this.$toast.warning("Vui lòng chọn hình thức thanh toán");
                return false;
            }
            return true;
        },
        detailProduct(data) {
            this.$router.push({ name: 'product', params: { id: data.productID } });
        },
        // Click nút Đặt hàng
        orderProduct() {
            // Check validate -- làm sau
            // let isValid = this.validateBeforeSave(this.customerInfo);
            // if (!isValid) {
            //     return;
            // }
            this.handleOrder();
        },

        handleOrder() {
            const me = this;
            this.prepareBeforeHandle();
            let orderParam = {
                order: JSON.stringify(this.customerInfo),
                orderdetail: JSON.stringify(this.listOrderDetail),
            };
            console.log(orderParam);

            // axios.post("https://localhost:7129/api/v1/Orders/insertOrderDetail", orderParam)
            axios.post(ApiOrder.insertOrderDetail(), orderParam)
                .then((res) => {
                    console.log(res);
                    if (res.status == 201) {
                        alert("Đơn hàng đã được đặt thành công");
                        this.$router.push('/order');
                    } else {
                        alert("Có lỗi xảy ra")
                    }
                })
            // OrderService.insertOrderDetail(orderParam).then((result) => {
            //     if (result && result.data) {
            //         if (result.data.success) {
            //             if (me.checkOutTypeID == 1) {
            //                 // thanh toán qua vnpay
            //                 let param = {
            //                     Amount: me.totalAmount,
            //                 };

            //                 PaymentService.getVNPayLink(param)
            //                     .then((result) => {
            //                         if (result && result.data) {
            //                             let vnpayUrl = result.data.data;
            //                             window.location.href = vnpayUrl;
            //                         }
            //                     })
            //                     .catch((e) => {
            //                         console.log(e);
            //                     });
            //             } else {
            //                 me.$toast.success("Đặt mua hàng thành công!");
            //                 this.$router.push({
            //                     name: "c-checkout-result",
            //                 });
            //             }
            //         } else {
            //             me.$toast.error(result.data.errorMessage);
            //         }
            //     }
            // });
        },

        /**\
         * Chuẩn bị dữ liệu trước khi đặt hàng
         */
        prepareBeforeHandle() {
            this.customerInfo["orderCode"] = '';
            this.customerInfo["orderDate"] = new Date();
            this.customerInfo["idUser"] = this.userID;
            this.customerInfo["fullName"] = this.fullName;
            this.customerInfo["address"] = this.address;
            this.customerInfo["phoneNumber"] = this.phoneNumber;
            this.customerInfo["description"] = this.description;
            this.customerInfo["totalAmount"] = this.totalAmount;
            this.customerInfo["statusOrders"] = 2; // chờ tiếp nhận
            this.customerInfo["checkOutTypeID"] = this.checkOutTypeID; // Thanh toán tại nhà
            this.customerInfo["CheckOutStatusID"] = 2 // Chưa thanh toán

            // this.customerInfo["totalprice"] = this.totalAmount;
            // Xử lý danh sách các hàng hóa mua
            console.log(this.customerInfo);
            // Xử lý danh sách các hàng hóa mua
            this.listOrderDetail = this.listCart.map((x) => ({
                idOrderDetail: "",
                price: x.price,
                productCode: x.productCode,
                productID: x.productID,
                productName: x.productName,
                quantitys: x.quantitys
            }));
            console.log(this.listOrderDetail);
        },

    },
    created() {
        this.showLoading = true;
        const id = localStorage.getItem("UserID");
        setTimeout(() => {
            this.showLoading = false;
            axios.get(ApiUser.getUserById(id))
                .then((res) => {
                    if (res.status == 200) {
                        this.user = res.data;
                        // console.log(this.user);
                        this.userID = this.user.userID;
                        this.fullName = this.user.fullName
                        this.address = this.user.address
                        this.phoneNumber = this.user.phoneNumber
                    }
                })
            this.listCart = this.$store.state.cart.items;
        }, 500);
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        checkOutTypeID(newVal) {
            this.checkOutTypeID = newVal;
            if (newVal == 1) {
                this.showPayVnPay = true;
            } else {
                this.showPayVnPay = false;
            }
        }
    },
    computed: {
        totalAmount() {
            return this.$store.state.cart.items.reduce((total, item) => total + (item.price * item.quantitys), 0);
        },
    }
}
</script>
  
<style>
@import url(../../css/purcharse.css);
</style>