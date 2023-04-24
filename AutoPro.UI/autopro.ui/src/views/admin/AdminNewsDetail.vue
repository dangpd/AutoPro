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
                        Tiêu đề :
                    </div>
                    <MInput type="text" v-model="news.newsTitle"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1">
                    <div class="acol1-text">
                        Nội dung ngắn :
                    </div>
                    <MInput type="text" v-model="news.contentShorted"
                        styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;box-sizing: border-box;">
                    </MInput>
                </div>
                <div class="acol1">
                    <div class="acol1-text">
                        Nội dung :
                    </div>
                    <MInput type="text" v-model="news.content" styleInput="width: 400px; height: 30px; font-size:13px; padding-left:15px; border-radius:4px;">
                    </MInput>
                </div>
            </div>
            <div class="agroup1">
                <div class="acol1-image">
                    <div class="aco1-image-file">
                        <div class="acol1-text">
                            Hình ảnh :
                        </div>
                        <input type="file" ref="fileInput" @change="handleFileUpload()" />
                    </div>
                    <img :class="{ 'ImageNone': ImageNone }" :src="srcImage" alt=""
                        style="height: 100px;width: 100px;display: none;border: 1px solid #bbb;margin-left: 150px;margin-top: 10px;">
                </div>
            </div>
            <div class="acol2-link">
                <div class="acol1-text" style="width: 150px;">
                    Linh đường dẫn :
                </div>
                <MInput type="text" v-model="news.image" styleInput="width: 900px; height: 30px;">
                </MInput>
            </div>
            <div class="aformSave" @click="saveNews">
                <button>Lưu</button>
            </div>
        </div>
        <MLoading v-if="showLoading"></MLoading>
    </div>
</template>
  
<script>
import MInput from '@/components/MInput.vue'; import Resource from '../../js/gResource';
import axios from 'axios';
import {
    getDownloadURL,
    getStorage,
    ref,
    uploadBytesResumable,
} from "firebase/storage";
import MLoading from '@/components/MLoading.vue';
import ApiNews from '../../js/apiNews';
import MDatePicker from '@/components/MDatePicker.vue';
export default {
    /**
     * Tên component
     */
    name: "AdminNewsDetail",
    /**
     * Hứng nhận
     */
    props: ["id", "type"],
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
            news: {
                newsDate: new Date(),
            },
            showLoading: false,
            title: '',
            srcImage: "",
            ImageNone: false
        };
    },
    /**
     * Phương thức
     */
    methods: {
        async handleFileUpload() {
            //   const storageRef = ref(storage, "user/" + this.file.name);
            //   console.log(this.$refs.fileInput.files[0]);
            //   uploadBytes(storageRef,this.$refs.fileInput.files[0])
            //   .then((snapshot) => {
            //     console.log("ok");
            //   });
            let file = this.$refs.fileInput.files[0];
            const storage = getStorage();
            //   const metadata = {
            //     contentType: "image/jpeg/png",
            //   };
            const storageRef = ref(storage, "News/" + file.name);
            const uploadTask = uploadBytesResumable(
                storageRef,
                this.$refs.fileInput.files[0]
                // metadata
            );

            uploadTask.on(
                "state_changed",
                (snapshot) => {
                    // console.log(snapshot);
                    let process = (snapshot.bytesTransferred / snapshot.totalBytes) * 100;
                    // console.log(process);
                    if (process == 100) {
                        console.log("tải ảnh lên thành công");
                    }
                },
                (error) => {
                    console.log(error);
                    alert("Tải ảnh lỗi");
                },
                () => {
                    // uploadTask.pause();
                    // Handle successful uploads on complete
                    // For instance, get the download URL: https://firebasestorage.googleapis.com/...
                    getDownloadURL(uploadTask.snapshot.ref).then((downloadURL) => {
                        // console.log(downloadURL);
                        this.srcImage = downloadURL;
                        this.ImageNone = true;
                        this.news.image = downloadURL;
                        alert("Đã tải ảnh xong");
                    });
                }
            );
        },
        onClose() {
            // uploadTask.cancel();
            this.$emit("onClose");
        },

        formatDate(datetime) {
            try {
                return formatDate(datetime);
            } catch (error) {
                console.log(error);
            }
        },
        async saveNews() {
            setTimeout(async () => {
                if (this.type == Resource.FormAdminType.Add) {
                    await axios.post(ApiNews.addNews(), this.news)
                        .then((res) => {
                            if (res.status == 201) {
                                this.$emit("onClose");
                                this.$emit("success");
                            }
                        })
                        .catch((err) => {
                            console.log(err);
                        })
                } else {
                    this.news.image = this.srcImage;
                    await axios.put(ApiNews.updateNews(this.id), this.news)
                        .then((res) => {
                            if (res.status == 200) {
                                this.$emit("success");
                                this.$emit("onClose");
                            }
                        })
                        .catch((err) => {
                            console.log(err);
                        })
                }
            }, 1000)
        }
    },
    created() {
        this.srcImage = "";
        // Khởi tạo lấy giá trị id truyền vào
        if (this.id) {
            // Bật loadding
            this.showLoading = true;
            setTimeout(() => {
                this.title = Resource.TitleFormAdmin.UpdateNews;
                //Lấy dữ liệu
                axios.get(ApiNews.getNewsByID(this.id))
                    .then((res) => {
                        this.showLoading = false;
                        this.news = res.data;
                        this.srcImage = res.data.image;
                        if (this.srcImage) {
                            this.ImageNone = true;
                        }
                        // console.log(this.srcImage);
                    })
            }, 1000)
        } else {
            this.title = Resource.TitleFormAdmin.AddNews;
        }
    },
    /**
     * Theo dõi sự thay đổi
     */
    watch: {
        srcImage(newVal) {
            this.news.image = newVal;
        }
    },
};
</script>
  
<style>
@import url(../../css/admin/adminaccount.css);
</style>