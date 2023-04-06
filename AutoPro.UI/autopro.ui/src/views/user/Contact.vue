<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Liên hệ"></TheLineLink>
            <div class="content-contact">
                sitemap
            </div>
            <div class="contact-email">
                <div>
                    <h6 style="margin-top: 8px;">Liên hệ với chúng tôi</h6>
                    <p>Địa chỉ :Số 23 - Ngõ 62 - Đường Trần Bình - Quận Cầu Giấy - Hà Nội</p>
                    <h6>Thời gian làm việc</h6>
                    <p>Từ 8h30 đến 17h30 từ thứ 2 đến thứ 7</p>
                    <h6>Hotline hỗ trợ</h6>
                    <p>0394061318</p>
                </div>
                <div class="form-contact">
                    <div>
                        <h6 style="font-weight: 600;">Email cho chúng tôi</h6>
                        <div class="contact-name">
                            <div class="text">Họ và tên:</div>
                            <MInput type="text"
                                styleInput="width: 300px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                            </MInput>
                        </div>
                        <div class="contact-email">
                            <div class="text">Email :</div>
                            <MInput type="email"
                                styleInput="width: 300px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                            </MInput>
                        </div>
                        <div class="contact-phone">
                            <div class="text">Số điện thoại:</div>
                            <MInput type="text"
                                styleInput="width: 300px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                            </MInput>
                        </div>
                    </div>
                    <div style="margin-top: 26px; padding-left: 8px;">
                        <div class="contact-noidung">
                            <div class="text">Nội dung:</div>
                            <MInput type="text"
                                styleInput="width: 400px; height: 90px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                            </MInput>
                        </div>
                        <div class="contact-submit">
                            <MInput type="submit" styleInput="width: 50px; height: 36px; font-size:13px;margin-top:8px;margin-left:350px">
                            </MInput>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <TheFooter></TheFooter>
    </div>
</template>

<script>

import TheHeader from '@/layout/TheHeader.vue';
import TheLineLink from '@/layout/TheLineLink.vue';
import TheNavbar from '@/layout/TheNavbar.vue';
import MInput from '@/components/MInput.vue';
import TheFooter from '@/layout/TheFooter.vue';
export default {
    /**
     * Tên component
     */
    name: 'Contact',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: { TheHeader, TheNavbar, TheLineLink, MInput, TheFooter },
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

        }
    },
    /**
     * Phương thức
     */
    methods: {

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
@import url(../../css/contact.css);
</style>