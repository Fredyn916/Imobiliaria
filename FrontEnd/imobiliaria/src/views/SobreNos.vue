<template>
    <section class="sobre-nos">
        <!-- Equipe -->
        <div class="equipe-container">
            <h2 class="fade-in">Conheça Nossa Equipe</h2>
            <div class="equipe">
                <div class="membro" v-for="(membro, index) in equipe" :key="index">
                    <div class="avatar">
                        <img :src="membro.imagem" :alt="membro.nome">
                    </div>
                    <h3>{{ membro.nome }}</h3>
                    <p>{{ membro.cargo }}</p>
                </div>
            </div>
        </div>

        <!-- Mapa Interativo com Seta -->
        <div class="mapa-container">
            <h2 class="slide-in">Encontre-nos Aqui</h2>
            <div class="mapa">
                <iframe
                    src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3752.489536960225!2d-43.800050!3d-19.885810!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0xa697d7b071d817%3A0x91db7757c493ff25!2sLocaliza%C3%A7%C3%A3o!5e0!3m2!1spt-BR!2sbr!4v1639654695688!5m2!1spt-BR!2sbr&markers=color:red%7C-19.885810,-43.800050"
                    width="100%" height="400px" style="border:0;" allowfullscreen="" loading="lazy">
                </iframe>
            </div>
        </div>

    </section>
</template>

<script>
export default {
    name: 'SobreNos',
    data() {
        return {
            equipe: [
                { nome: 'Guilherme Santos', cargo: 'Desenvolvedor Front End', imagem: '/src/Images/Guilherme.png' },
                { nome: 'Frederico Marques', cargo: 'Desenvolvedor Back End', imagem: '/src/Images/Fred.png' }
            ]
        };
    },
};
</script>

<style scoped>
.equipe-container,
.mapa-container {
    padding: 2rem;
    text-align: center;
}

.fade-in {
    animation: fadeIn 1s ease-in-out;
}

.slide-in {
    animation: slideInUp 1s ease-in-out;
}

@keyframes fadeIn {
    from {
        opacity: 0;
    }

    to {
        opacity: 1;
    }
}

@keyframes slideInUp {
    from {
        transform: translateY(50px);
        opacity: 0;
    }

    to {
        transform: translateY(0);
        opacity: 1;
    }
}

.mapa {
    position: relative;
}

.avatar {
    margin: 1rem auto;
    display: flex;
    justify-content: center;
    align-items: center;
    width: 150px;
    height: 150px;
    border-radius: 50%;
    overflow: hidden;
    box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
    transition: transform 0.3s ease;
}

.avatar img {
    width: 100%;
    height: 100%;
    object-fit: cover;
}

.membro:hover .avatar {
    transform: scale(1.1);
}

.membro h3 {
    margin-top: 0.5rem;
    font-size: 1.2rem;
    color: #333;
}

.membro p {
    color: #777;
    font-size: 1rem;
    margin-top: 0.2rem;
}

@keyframes bounce {

    0%,
    100% {
        transform: translateY(0);
    }

    50% {
        transform: translateY(-10px);
    }
}
</style>
