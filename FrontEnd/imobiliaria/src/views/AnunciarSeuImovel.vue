<template>
    <div class="container">
        <div class="Etapas">
            <p class="Etapa" :class="{ 'escuro': step === 1 }">Tipo de Imóvel</p>
            <p class="Etapa" :class="{ 'escuro': step === 2 }">Localização</p>
            <p class="Etapa" :class="{ 'escuro': step === 3 }">Características</p>
        </div>

        <div class="internal__container">
            <div class="container__tittle">
                <h1>Anuncie seu Imóvel</h1>
            </div>
            <div class="add-imoveis-box">
                <form @submit.prevent="PostImovel">
                    <!-- Etapa 1 -->
                    <div v-if="step === 1">
                        <div class="select-status">
                            <button type="button" class="select-status-btn"
                                :class="{ active: selectedStatus === 'Venda' }" @click="selectedStatus = 'Venda'">
                                Venda
                            </button>
                            <button type="button" class="select-status-btn"
                                :class="{ active: selectedStatus === 'Aluguel' }" @click="selectedStatus = 'Aluguel'">
                                Aluguel
                            </button>
                            <button type="button" class="select-status-btn"
                                :class="{ active: selectedStatus === 'Temporada' }"
                                @click="selectedStatus = 'Temporada'">
                                Temporada
                            </button>
                        </div>

                        <select v-model="selectedProperty" class="property-select">
                            <option value="">Selecione um tipo de imóvel</option>
                            <option value="Apartamento">Apartamento</option>
                            <option value="Casa">Casa</option>
                            <option value="Comercial">Comercial</option>
                            <option value="Lote">Lote</option>
                            <option value="Rural">Rural</option>
                            <option value="Terreno">Terreno</option>
                        </select>

                        <button type="button" @click="nextStep" :disabled="!selectedProperty || !selectedStatus">
                            Próxima Etapa
                        </button>
                    </div>

                    <!-- Etapa 2 -->
                    <div v-if="step === 2" class="step2">
                        <h2>Detalhes do Imóvel</h2>

                        <label for="anos">Idade do Imovel</label>
                        <input type="text" id="anos" v-model="anos" />

                        <label for="cep">CEP</label>
                        <input type="text" id="cep" v-model="cep" @blur="buscarCep" />

                        <label for="rua">Rua</label>
                        <input type="text" id="rua" v-model="rua" />

                        <label for="numero">Número</label>
                        <input type="text" id="numero" v-model="numero" />


                        <label for="unidadeFederativa">Estado</label>
                        <input type="text" id="unidadeFederativa" v-model="unidadeFederativa" />

                        <label for="cidade">Cidade</label>
                        <input type="text" id="cidade" v-model="cidade" />

                        <label for="bairro">Bairro</label>
                        <input type="text" id="bairro" v-model="bairro" />

                        <div class="form-group">
                            <label for="image">Fotos do Imóvel:</label>
                            <input type="file" id="image" @change="handleFileUpload" />
                        </div>

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
                                <label>Área (m²):</label>
                                <input type="number" v-model="area" />

                                <label>Valor (R$):</label>
                                <input type="text" v-model="preco" />
                            </div>
                        </div>

                        <label for="titulo">Título:</label>
                        <input type="text" id="titulo" v-model="titulo" required />

                        <label for="descricao">Descrição:</label>
                        <textarea id="descricao" v-model="descricao"></textarea>

                        <button type="button" @click="prevStep">Voltar</button>
                        <button type="submit">Anunciar</button>
                    </div>
                </form>
            </div>
        </div>
    </div>
</template>

<script>export default {
    name: "AnunciarSeuImovel",
    data() {
        return {
            step: 1,
            selectedStatus: "",
            selectedProperty: "",
            anos: 0,
            cep: "",
            rua: "",
            numero: 0,
            unidadeFederativa: "",
            cidade: "",
            bairro: "",
            quartos: 0,
            banheiros: 0,
            garagens: 0,
            area: 0,
            preco: "",
            titulo: "",
            descricao: "",
            selectedFile: null,
        };
    },
    methods: {
        handleFileUpload(event) {
            this.selectedFile = event.target.files[0];
        },
        nextStep() {
            if (this.step < 3) this.step++;
        },
        prevStep() {
            if (this.step > 1) this.step--;
        },

        async buscarCep() {
            if (!this.cep || this.cep.length !== 8) {
                alert('CEP inválido');
                return;
            }

            try {
                const response = await fetch(`https://viacep.com.br/ws/${this.cep}/json/`);
                const data = await response.json();

                if (!data.erro) {
                    this.rua = data.logradouro;
                    this.bairro = data.bairro;
                    this.cidade = data.localidade;
                    this.unidadeFederativa = data.uf;
                } else {
                    alert('CEP não encontrado');
                }
            } catch (error) {
                alert('Erro ao buscar o CEP');
            }
        },
        async PostImovel(e) {
            e.preventDefault();
            const data = {
                id: null, // Campo opcional, substitua conforme necessário
                tipo: this.selectedProperty || "string",
                area: this.area || 0,
                preco: parseFloat(this.preco) || 0,
                anos: this.anos || 0,
                tipoServico: this.selectedStatus || "string",
                cep: this.cep || "string",
                rua: this.rua || "string",
                numero: parseInt(this.numero) || 0,
                bairro: this.bairro || "string",
                cidade: this.cidade || "string",
                unidadeFederativa: this.unidadeFederativa || "string",
                endereco: `${this.rua}, ${this.numero}, ${this.bairro}, ${this.cidade}, ${this.unidadeFederativa}` || "string",
                urLsImagens: [], // Substitua após implementar o upload de imagens
                titulo: this.titulo || "string",
                descricao: this.descricao || "string",
                areasComuns: [
                    `Quartos: ${this.quartos}`,
                    `Banheiros: ${this.banheiros}`,
                    `Garagens: ${this.garagens}`,
                ],
            };
            const dataJson = JSON.stringify(data)
            console.log(data)

            const response = await fetch('https://localhost:7082/Imovel/AdicionarImovel', {
                method: 'POST',
                headers: { 'Content-Type': 'application/json' },
                body: dataJson
            });

            const responseData = await response.json();
            const responseID = responseData.id;

            const formData = new FormData();
            formData.append("imagem", this.selectedFile);

            const responsePostImagem = await fetch(`https://localhost:7082/Imovel/UploadImage?imovelId=${responseID}`, {
                method: "PUT",
                body: formData,
            });

        },
    },
};

</script>


<style scoped>
.container {
    display: flex;
    align-items: center;
    padding: 20px;
    font-family: "Funnel Display", sans-serif;
    background-color: #f4f4f9;
    min-height: 150vh;
}

.Etapas {
    border: 1px solid black;
    background-color: #FFF;
    border-radius: 10px;
    height: auto;
    min-height: 130px;
    width: 200px;
}

.Etapa {
    color: #888;
    font-weight: normal;
    height: 30%;
    min-height: 50px;
    display: flex;
    align-items: center;
    justify-content: center;
}

.Etapa.escuro {
    color: #333;
    background-color: #ededed;
    font-weight: bold;
    border-radius: 10px;
}



.internal__container {
    width: 100%;
    display: flex;
    flex-direction: column;
    text-align: center;
    align-items: center;
    justify-content: center;
}

.container__tittle {
    width: 100%;
    height: 120px;
    display: flex;
    justify-content: center;
    align-items: center;

}

label {
    color: #333;
    font-weight: 600;
}

.add-imoveis-box {
    width: 100%;
    max-width: 900px;
    height: auto;
    max-height: 900px;
    padding: 20px;
    background-color: #ffffff;
    border-radius: 8px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    margin-top: 20px;
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
    height: 60px;
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
    transition: 0.3s;
}

.select-status-btn.active {
    background-color: #FFF;
    border: 3px solid rgb(0, 43, 82);
    color: #000;
    transform: scale(1.1);
}

.property-select {
    width: 100%;
    padding: 10px;
    margin: 20px 0;
    border: 2px solid #ddd;
    border-radius: 4px;
    font-size: 14px;
}

button {
    padding: 10px 20px;
    margin: 10px 0;
    background-color: rgb(0, 43, 82);
    color: white;
    border: none;
    border-radius: 4px;
    cursor: pointer;
    transition: 0.3s;
    width: 100%;
}

button:disabled {
    background-color: #ccc;
    cursor: not-allowed;
}

button:hover {
    background-color: #1A5276;
    transform: scale(1.05);
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
    font-weight: bold;
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
