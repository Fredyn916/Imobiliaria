<template>
    <div class="Echo__Container">
        <div class="Echo__Box">
            {{ content }}
        </div>
    </div>
</template>

<script>
export default {
    name: 'Echo',
    props: {
        content: {
            type: String,
            default: 'Conteúdo padrão do Echo'
        }
    }
}
</script>

<style scoped>
.Echo__Container {
    width: 100%;
    display: flex;
    justify-content: center;
    align-items: center;
    padding: 20px;
}

.Echo__Box {
    width: 80%;
    height: 500px;
    background-color: aliceblue;
    border: 1px solid #333;
    color: #333;
    padding: 20px;
    border-radius: 8px;
    display: flex;
    justify-content: center;
    align-items: center;
    font-size: 1.2em;
    text-align: center;
}
</style>
