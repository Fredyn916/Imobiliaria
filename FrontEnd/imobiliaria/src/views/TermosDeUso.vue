<template>
    <div class="terms__container">
        <div class="terms__content">
            <h1>Termos de Uso</h1>
            <p>Bem-vindo ao nosso site! Ao acessar ou usar nossos serviços, você concorda com os termos descritos
                abaixo. Por favor, leia atentamente.</p>
            <div class="terms__text">
                <p></p>
            </div>
        </div>
    </div>
</template>

<script>
export default {
    name: 'TermosDeUso'
}
</script>

<style scoped>
.terms__container {
    display: flex;
    justify-content: center;
    align-items: center;
    height: 100vh;
    background-color: #f0f0f0;
    padding: 20px;
}

.terms__content {
    background: #fff;
    padding: 40px;
    border-radius: 12px;
    box-shadow: 0 8px 20px rgba(0, 0, 0, 0.1);
    width: 80%;
    max-width: 900px;
    overflow-y: auto;
    max-height: 90vh;
    font-family: 'Arial', sans-serif;
}

h1 {
    font-size: 2.5rem;
    margin-bottom: 20px;
    color: #333;
    text-align: center;
    font-weight: bold;
}

.terms__text p {
    font-size: 1.1rem;
    color: #555;
    line-height: 1.8;
    margin-bottom: 16px;
}

.terms__text p strong {
    color: #333;
}

.term__text p:last-child {
    margin-bottom: 0;
}
</style>
