<template>
    <h1>Apartamento</h1>
    <div class="imovel-box-images">
        <div v-for="(imagem, index) in Imovel.urLsImagens" :key="index">
            <img v-if="imagem" :src="imagem" alt="Imagem do imóvel" class="imovel-image" />
        </div>
    </div>


    <div v-if="Imovel && Object.keys(Imovel).length > 0">

        <div class="Imovel__preco"><strong> R$ {{ Imovel.preco }}</strong></div>
        <div class="Imovel__rua">{{ Imovel.rua }}</div>
        <div class="Imovel__anos">{{ Imovel.anos }}</div>
        <div class="Imovel__cep">{{ Imovel.cep }}</div>
        <div class="Imovel__descricao">{{ Imovel.descricao }}</div>
        <div class="Imovel__endereco">{{ Imovel.endereco }}</div>
        <div class="Imovel__areasComuns">
            <ul>
                <li v-for="area in Imovel.areasComuns" :key="area">{{ area }}</li>
            </ul>
        </div>
        <div class="Imovel__area">{{ Imovel.area }} m²</div>
        <div class="Imovel__descricao">{{ Imovel.descricao }}</div>

    </div>
    <div v-else>
        <p>Carregando detalhes do imóvel...</p>
    </div>
</template>

<script>
export default {
    name: 'ViewOneImovelApartamento',
    data() {
        return {
            Imovel: {}
        };
    },
    mounted() {
        const imovelId = this.$route.query.id;
        if (imovelId) {
            this.carregarImovel(imovelId);
        }
    },
    methods: {
        async carregarImovel(imovelId) {
            try {
                const apiUrl = `https://localhost:7082/Imovel/ListarImovelPorId?id=${imovelId}`;
                const response = await fetch(apiUrl, {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                    },
                });

                if (!response.ok) {
                    throw new Error('Erro ao buscar detalhes do imóvel.');
                }

                const data = await response.json();
                this.Imovel = data;
                console.log('Detalhes do Imóvel:', this.Imovel);
            } catch (error) {
                console.error('Erro ao carregar detalhes do imóvel:', error);
            }
        }
    }
};
</script>

<style scoped></style>
