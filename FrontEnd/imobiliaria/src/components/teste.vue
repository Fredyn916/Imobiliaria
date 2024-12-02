<template>
    <div>
        <h2>Upload de Imagem</h2>
        <input type="file" @change="onFileChange">
        <button @click="uploadImage">Enviar</button>
    </div>
</template>

<script>
export default {
    data() {
        return {
            selectedFile: null,
        };
    },
    methods: {
        onFileChange(event) {
            this.selectedFile = event.target.files[0];
        },
        async uploadImage() {
            const formData = new FormData();
            formData.append('file', this.selectedFile);


            console.log(formData)
        },
    },
};
</script>