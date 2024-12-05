<template>
    <div class="container">
        <h1>Anuncie o Seu Imóvel</h1>
        <div class="add-imoveis-box">
            <form @submit.prevent="PostImovel">
                <!-- Etapa 1 -->
                <div v-if="step === 1">
                    <div class="select-status">
                        <button type="button" class="select-status-btn" :class="{ active: selectedStatus === 'Venda' }"
                            @click="selectedStatus = 'Venda'">Venda</button>
                        <button type="button" class="select-status-btn"
                            :class="{ active: selectedStatus === 'Aluguel' }"
                            @click="selectedStatus = 'Aluguel'">Aluguel</button>
                        <button type="button" class="select-status-btn"
                            :class="{ active: selectedStatus === 'Temporada' }"
                            @click="selectedStatus = 'Temporada'">Temporada</button>
                    </div>

                    <select v-model="selectedProperty" class="property-select">
                        <option value="">Selecione um tipo de imóvel</option>
                        <option value="Apartamento">Apartamento</option>
                        <option value="Casa">Casa</option>
                        <option value="Comercial">Comercial</option>
                        <option value="Rural">Rural</option>
                        <option value="Terreno">Terreno</option>
                    </select>

                    <button type="button" @click="nextStep" :disabled="!selectedProperty || !selectedStatus">Próxima
                        Etapa</button>
                </div>

                <!-- Etapa 2 -->
                <div v-if="step === 2" class="step2">
                    <h2>Detalhes do Imóvel</h2>
                    <label for="cep">CEP:</label>
                    <input type="text" id="cep" v-model="cep" />

                    <label for="rua">Rua:</label>
                    <input type="text" id="rua" v-model="rua" />

                    <label for="unidadeFederativa">Estado:</label>
                    <input type="text" id="unidadeFederativa" v-model="unidadeFederativa" />

                    <label for="cidade">Cidade:</label>
                    <input type="text" id="cidade" v-model="cidade" />

                    <label for="bairro">Bairro:</label>
                    <input type="text" id="bairro" v-model="bairro" />

                    <label for="photo">Foto do Imóvel:</label>
                    <input type="file" id="photo" @change="handleFileUpload" />

                    <button type="button" @click="nextStep">Próxima Etapa</button>
                    <button type="button" @click="prevStep">Voltar</button>
                </div>

                <!-- Etapa 3 -->
                <div v-if="step === 3" class="step3">
                    <h2>Informações Adicionais</h2>
                    <div class="property-inputs">
                        <div class="counter-group">
                            <div class="counter">
                                <label>Quartos</label>
                                <div class="counter-controls">
                                    <button type="button" @click="quartos = Math.max(quartos - 1, 0)">-</button>
                                    <input type="number" v-model="quartos" readonly />
                                    <button type="button" @click="quartos++">+</button>
                                </div>
                            </div>
                            <div class="counter">
                                <label>Banheiros</label>
                                <div class="counter-controls">
                                    <button type="button" @click="banheiros = Math.max(banheiros - 1, 0)">-</button>
                                    <input type="number" v-model="banheiros" readonly />
                                    <button type="button" @click="banheiros++">+</button>
                                </div>
                            </div>
                            <div class="counter">
                                <label>Garagens</label>
                                <div class="counter-controls">
                                    <button type="button" @click="garagens = Math.max(garagens - 1, 0)">-</button>
                                    <input type="number" v-model="garagens" readonly />
                                    <button type="button" @click="garagens++">+</button>
                                </div>
                            </div>
                        </div>

                        <div class="area-group">
                            <label>Área Total (m²):</label>
                            <input type="number" v-model="areaTotal" />

                            <label>Valor (R$):</label>
                            <input type="text" v-model="preco" />
                        </div>
                    </div>

                    <label for="titulo">Título:</label>
                    <input type="text" id="titulo" v-model="titulo" required />

                    <label for="descricao">Descrição:</label>
                    <textarea id="descricao" v-model="description"></textarea>


                    <button type="button" @click="prevStep">Voltar</button>
                    <button v-if="step === 3" type="button" @click="PostImovel">Anunciar</button>
                </div>
            </form>
        </div>
    </div>
</template>

<script>
export default {
    name: "AnunciarSeuImovel",
    data() {
        return {
            step: 1,
            selectedStatus: "",
            selectedProperty: "",
            description: "",
            price: null,
            photo: null,
            postCompleted: false,
            cep: "",
            rua: "",
            unidadeFederativa: "",
            cidade: "",
            bairro: "",
            quartos: 0,
            banheiros: 0,
            suites: 0,
            garagens: 0,
            areaUtil: 0,
            areaTotal: 0,
            preco: "",
            titulo: "",
            descricao: "",
        };
    },
    methods: {
        nextStep() {
            if (this.step < 3) {
                this.step++;
            }
        },
        prevStep() {
            if (this.step > 1) {
                this.step--;
            }
        },
        handleFileUpload(event) {
            const file = event.target.files[0];
            if (file) {
                const reader = new FileReader();
                reader.onload = (e) => {
                    this.photo = e.target.result;
                };
                reader.readAsDataURL(file);
            }
        },
        async PostImovel() {

            const data = {
                selectedStatus: this.selectedStatus,
                selectedProperty: this.selectedProperty,
                description: this.description,
                preco: this.preco,
                cep: this.cep,
                rua: this.rua,
                unidadeFederativa: this.unidadeFederativa,
                cidade: this.cidade,
                bairro: this.bairro,
                quartos: this.quartos,
                banheiros: this.banheiros,
                suites: this.suites,
                garagens: this.garagens,
                areaUtil: this.areaUtil,
                areaTotal: this.areaTotal,
                titulo: this.titulo,
                descricao: this.descricao,
            }

            const dataJson = JSON.stringify(data)
            console.log(dataJson)
            alert("Imóvel Anunciado com sucesso!");
            await LimparForm()
            this.step = 1;
        },
        LimparForm() {
            this.selectedStatus = "";
            this.selectedProperty = "";
            this.description = "";
            this.photo = null;
            this.cep = "";
            this.rua = "";
            this.unidadeFederativa = "";
            this.cidade = "";
            this.bairro = "";
            this.quartos = 0;
            this.banheiros = 0;
            this.suites = 0;
            this.garagens = 0;
            this.areaUtil = 0;
            this.areaTotal = 0;
            this.preco = "";
            this.titulo = "";
            this.descricao = "";
        }
    },
};
</script>

<style scoped>
.container {
    display: flex;
    flex-direction: column;
    align-items: center;
    padding: 20px;
    font-family: Arial, sans-serif;
    background-color: #f4f4f9;
    min-height: 100vh;
}

.add-imoveis-box {
    width: 100%;
    max-width: 600px;
    padding: 20px;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}

h1,
h2 {
    color: #333;
    text-align: center;
}

.select-status {
    display: flex;
    justify-content: space-between;
    margin-bottom: 20px;
}

.select-status-btn {
    flex: 1;
    margin: 0 5px;
    padding: 15px;
    font-size: 16px;
    color: white;
    border: 1px solid #ddd;
    border-radius: 4px;
    background-color: rgb(0, 43, 82);
    cursor: pointer;
    transition: all 0.3s ease;
}

.select-status-btn.active {
    background-color: #FFF;
    border: 1px solid rgb(0, 43, 82);
    color: #000;
}

.property-select {
    width: 100%;
    padding: 10px;
    margin: 20px 0;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 14px;
}

button {
    padding: 10px 20px;
    margin: 10px 0;
    background-color: #1A5276;
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

button:disabled {
    background-color: #ccc;
    cursor: not-allowed;
}


.property-inputs {
    display: flex;
    flex-direction: column;
    gap: 2rem;
}

.counter-group,
.area-group {
    display: flex;
    flex-wrap: wrap;
    gap: 1.5rem;
}

.counter,
.area-input {
    display: flex;
    flex-direction: column;
    width: 200px;
}

.counter-controls {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

.counter-controls button {
    width: 40px;
    height: 40px;
    background-color: #1A5276;
    color: white;
    border: none;
    border-radius: 4px;
    font-size: 18px;
    font-weight: bold;
    cursor: pointer;
    transition: background-color 0.3s ease;
}

.counter-controls button:hover {
    background-color: #154360;
}

.property-inputs input[type="number"] {
    width: 60px;
    text-align: center;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 16px;
    padding: 5px;
}

.property-inputs input[type="text"] {
    width: 60px;
    text-align: center;
    border: 1px solid #ddd;
    border-radius: 4px;
    font-size: 16px;
    padding: 5px;
}

.input-wrapper {
    display: flex;
    align-items: center;
    gap: 0.5rem;
}

.property-inputs span {
    font-size: 1rem;
}

.step2 {
    display: flex;
    flex-direction: column;
}

.step2 input {
    border: 3px solid #ededed;
    border-radius: 7px;
    margin-top: 13px;
    padding: 1rem;
}

.step3 {
    display: flex;
    flex-direction: column;
}

.step3 input,
textarea {
    border: 3px solid #ededed;
    border-radius: 7px;
    margin-top: 13px;
    padding: 1rem;
}

@media (max-width: 768px) {

    .counter,
    .area-input {
        width: 100%;
    }

    .select-status {
        flex-direction: column;
    }

    .select-status-btn {
        margin: 5px 0;
    }
}
</style>
