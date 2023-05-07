<template>
    <div>
        <div class="line-footer"></div>
        <div class="footer">
            <div class="footer-left">
                <router-link to="/" style="text-decoration: none;color: black;">
                    <img src="../assets/Image/logo3.jpg" alt="">
                    <h6 style="font-weight: 700;">Hệ thống phụ tùng Ô tô uy tín chính hãng</h6>
                </router-link>
                <div class="contact">
                    <img src="../assets/Image/CarlsonFacebook.png" alt="">
                    <img src="../assets/Image/icon_twitter_20x20.gif" alt="">
                    <img src="../assets/Image/social-icon-google-plus.png" alt="">
                    <img src="../assets/Image/youtube20.png" alt="">
                </div>
                <div class="certification">
                    <img src="../assets/Image/bct-dathongbao.png" alt="">
                </div>
            </div>
            <div class="footer-right">
                <div class="address-store">
                    <h4>ĐỊA CHỈ CỬA HÀNG</h4>
                    <h6>Cơ sở 1: Số 23- Ngõ 62 - Trần Bình - Cầu Giấy - Hà Nội</h6>
                    <h6>Cơ sở 2: Tô Ngọc Vân - P.Thạnh Xuân - Q.12 - HCM</h6>
                    <h6>Điện thoại: 0915.76.5555 - 0355. 999. 336 - 0961.399.499 - 0942.399.366 - 0988.550.306</h6>
                    <h6> Giấy phép Đăng ký kinh doanh số 0105878779 do sở KHĐT TP.Hà Nội cấp ngày 4/5/2012
                        Copyright © 2012 - 2023 AutoPro.com</h6>
                </div>
                <div class="sitemap">
                    <iframe
                        src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3724.6681061035583!2d105.72515037492835!3d21.005937180637723!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x313453724d4e75c1%3A0x5105c875ecde97a5!2sThe%20Golden%20An%20Khanh%2032T!5e0!3m2!1svi!2s!4v1681904654277!5m2!1svi!2s"
                        width="100%" height="100%" style="border:0;" allowfullscreen="" loading="lazy"
                        referrerpolicy="no-referrer-when-downgrade"></iframe>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    /**
       * Tên component
       */
    name: 'TheFooter',
    /**
     * Hứng nhận
     */
    props: [""],
    /**
     * Component được sử dụng
     */
    components: {},
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
@import url(../css/footer.css);
</style>