<template>
    <div>
        <div class="login">
            <img src="../../assets/Image/bglogin.png" alt="">

            <div class="form-register">
                <div class="title-form">
                    ĐĂNG KÍ
                </div>
                <div class="form-input">
                    <div class="register-account">
                        <div class="text">Tên đăng nhập :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-account">
                        <div class="text">Họ :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-account">
                        <div class="text">Tên :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-fullName">
                        <div class="text">Họ và tên :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-address">
                        <div class="text">Địa chỉ :</div>
                        <MInput type="text"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-account">
                        <div class="text">Avatar :</div>
                        <!-- <input type="file" ref="Avatar" @change="onFileInputChange" accept="image/*" />
                        <img v-if="imageUrl" :src="imageUrl" alt="Uploaded Image" /> -->
                        <!-- <input type="file" ref="fileInput" @change="handleFileUpload">
                        <button @click="uploadFile">Upload</button> -->
                        <!-- 
                        <input type="file" @change="handleImageChange">
                        <img :src="imageUrl" v-if="imageUrl"> -->

                        <input type="file" ref="fileInput" @change="handleFileUpload" />
                        <button type="button" @click="uploadFile">Upload</button>
                    </div>
                    <div class="register-birth">
                        <div class="text">Ngày sinh :</div>
                        <MInput type="date"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-gender">
                        <div class="text">Giới tính :</div>
                        <MInput type="radio">Nam</MInput>
                        <MInput type="radio">Nữ</MInput>
                        <MInput type="radio">Khác</MInput>
                    </div>
                    <div class="register-password">
                        <div class="text">Mật khẩu :</div>
                        <MInput type="password"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                    <div class="register-password">
                        <div class="text">Nhập lại mật khẩu :</div>
                        <MInput type="password"
                            styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                        </MInput>
                    </div>
                </div>
                <div class="submit">
                    <input type="submit" value="Đăng kí" style="padding: 4px ;" @click="register">
                </div>
                <div class="orther">
                    <router-link to="/account/sign-up" class="sign-up">Đăng nhập</router-link>
                    hoặc
                    <router-link to="/account/forgot-password" class="forgot-password">Quên mật khẩu ?</router-link>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
import TheFooter from '@/layout/TheFooter.vue';
import TheHeader from '@/layout/TheHeader.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MInput from '@/components/MInput.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import axios from 'axios';
export default {
    /**
     * Tên component
     */
    name: 'Register',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheFooter, MInput, TheLineLink },
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
            file: null,
            imageUrl: null
        }
    },
    /**
     * Phương thức
     */
    methods: {

        handleFileUpload() {
            this.file = this.$refs.fileInput.files[0];
        },
        uploadFile() {
            const formData = new FormData();
            formData.append('file', this.file);
            axios.post('https://localhost:7129/api/Upload/upload-image', formData).then(response => {
                console.log(response.data);
            });
        }
        // handleFileUpload() {
        //     this.file = this.$refs.fileInput.files[0];
        //     this.imageUrl = URL.createObjectURL(this.file);
        //     console.log(this.imageUrl);
        //     this.$store.dispatch('saveImageUrl', this.imageUrl);
        // },
        // uploadFile() {
        //     let formData = new FormData();
        //     formData.append('image', this.file);
        //     this.$store.dispatch('uploadImage', formData);
        // },
        // // ...mapActions(['saveImageUrl']),

        // onFileInputChange(event) {
        //     const file = event.target.files[0];
        //     const reader = new FileReader();
        //     reader.onload = (event) => {
        //         this.imageUrl = event.target.result;
        //     };
        //     reader.readAsDataURL(file);
        // },

        // handleImageChange(event) {
        //     const file = event.target.files[0];
        //     const reader = new FileReader();
        //     reader.onload = (e) => {
        //         this.imageUrl = e.target.result;
        //         console.log(this.imageUrl);
        //     };
        //     reader.readAsDataURL(file);
        // },
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
@import url(../../css/form.css);
</style>