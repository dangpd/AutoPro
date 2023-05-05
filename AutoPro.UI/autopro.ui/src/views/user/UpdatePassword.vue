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
            <div class="login-password">
                <div class="text">Mật khẩu cũ :</div>
                <MInput type='text'
                    styleInput="margin-left:150px;width: 800px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                    v-model="passwordOld">
                </MInput>
            </div>
            <div class="login-password">
                <div class="text">Mật khẩu mới:</div>
                <MInput :type="showPassword3 ? 'text' : 'password'"
                    styleInput="margin-left:150px;width: 800px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                    v-model="passwordNew">
                </MInput>
                <div class="login-show-password" @click="togglePasswordVisibility">
                    {{ showPassword3 ? 'Ẩn' : 'Hiện' }}
                </div>
            </div>
            <div class="login-password">
                <div class="text">Nhập lại mật khẩu mới:</div>
                <MInput :type="showPassword4 ? 'text' : 'password'"
                    styleInput="margin-left:150px;width: 800px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;"
                    v-model="confirmPasswordNew">
                </MInput>
                <div class="login-show-password" @click="togglePasswordVisibility2">
                    {{ showPassword4 ? 'Ẩn' : 'Hiện' }}
                </div>
            </div>
            <div class="aformSave">
                <button style="background-color: #206905;margin-left: 40px;color: white;" @click="questionSaveItem">Cập
                    nhật</button>
            </div>
        </div>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue';
import MLoading from '@/components/MLoading.vue';
import axios from 'axios';
import Resource from '@/js/gResource';
export default {
    /**
     * Tên component
     */
    name: "OrderDetail",
    /**
     * Hứng nhận
     */
    props: ["id"],
    /**
     * Component được sử dụng
     */
    components: { MInput, MLoading },
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
            idUser: '',
            passwordOld: '',
            passwordNew: '',
            confirmPasswordNew: '',
            title: '',
            showLoading: false,
            showPassword3: false,
            showPassword4: false,
        };
    },
    /**
     * Phương thức
     */
    methods: {
        questionSaveItem() {
            let text = `Bạn có muốn cập nhật mật khẩu không ?`;
            if (confirm(text) == true) {
                this.updatePasswordNew();
            } else {
                this.$emit("onClose");
            }
        },

        onClose() {
            this.$emit("onClose");
        },

        updatePasswordNew() {
            axios.put("https://localhost:7129/api/v1/User/updatePassword", { passold: this.passwordOld, id: this.idUser, passnew: this.passwordNew })
            .then((res)=>{
                console.log(res);
                if(res.status == 200){
                    alert("Cập nhật mật khẩu thành công");
                    this.$emit("onClose");
                }
            })
            .catch((err)=>{
                console.log(err);
                alert("Cập nhật mật khẩu thất bại");
            })
        },

        togglePasswordVisibility() {
            this.showPassword3 = !this.showPassword3;
        },

        togglePasswordVisibility2() {
            this.showPassword4 = !this.showPassword4;
        }

    },
    created() {
        let id = localStorage.getItem("UserID");
        this.title = Resource.TitleFormAdmin.updatePassword;
        this.idUser = id;
        if (this.id) {
            // Bật loadding
            setTimeout(() => {
            }, 200)
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