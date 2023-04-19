<template>
    <div>
        <TheHeader></TheHeader>
        <TheNavbar></TheNavbar>
        <div class="content">
            <TheLineLink name="Liên hệ"></TheLineLink>
            <div class="content-contact">
                <iframe
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.6681061035583!2d105.72515037492835!3d21.005937180637723!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x313453724d4e75c1%3A0x5105c875ecde97a5!2sThe%20Golden%20An%20Khanh%2032T!5e0!3m2!1svi!2s!4v1681904654277!5m2!1svi!2s"
                    width="100%" height="500px" style="border:0;" allowfullscreen="" loading="lazy"
                    referrerpolicy="no-referrer-when-downgrade"></iframe>
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
                            <MInput type="submit"
                                styleInput="width: 50px; height: 36px; font-size:13px;margin-top:8px;margin-left:350px">
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

<style>@import url(../../css/contact.css);</style>