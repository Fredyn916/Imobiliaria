<template>
    <div class="Precifier">
        <div class="Precifier__Bg">
        </div>
        <div class="Precifier__form">
            <div class="Precifier__top">
                <h1>Calcule quanto vale o seu Imóvel</h1>
                <h3>Preencha os dados e conheça o valor em segundos</h3>
            </div>
            <form @submit.prevent="PostPrecificador">
                <div class="form__group">
                    <label for="endereco">Endereço:</label>
                    <input type="text" id="endereco" v-model="endereco" placeholder="Endereço" required />
                </div>

                <div class="select__status__container">
                    <div class="select-status">
                        <label for="operacao">Tipo de operação?</label>
                        <div class="internal-select-status">
                            <button type="button" class="select-status-btn"
                                :class="{ active: vendaOuAluguel === 'Venda' }"
                                @click="vendaOuAluguel = 'Venda'">Venda</button>
                            <button type="button" class="select-status-btn"
                                :class="{ active: vendaOuAluguel === 'Aluguel' }"
                                @click="vendaOuAluguel = 'Aluguel'">Aluguel</button>
                        </div>
                    </div>

                    <div class="select-status">
                        <label for="novo">Seu Imóvel é novo?</label>
                        <div class="internal-select-status">
                            <button type="button" class="select-status-btn" :class="{ active: novo === true }"
                                @click="novo = true">Sim</button>
                            <button type="button" class="select-status-btn" :class="{ active: novo === false }"
                                @click="novo = false">Não</button>
                        </div>
                    </div>
                </div>

                <div class="select-status">
                    <label for="tipoImovel">Tipo de Imóvel?</label>
                    <div class="internal-select-status">
                        <button type="button" class="select-status-btn"
                            :class="{ active: tipoImovel === 'Apartamento' }"
                            @click="tipoImovel = 'Apartamento'">Apartamento</button>
                        <button type="button" class="select-status-btn" :class="{ active: tipoImovel === 'Casa' }"
                            @click="tipoImovel = 'Casa'">Casa</button>
                    </div>
                </div>

                <div class="property__inputs__container">
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
                                    <button type="button" @click="vagas = Math.max(vagas - 1, 0)">-</button>
                                    <input type="number" v-model="vagas" readonly />
                                    <button type="button" @click="vagas++">+</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>

                <div class="area__group__container">
                    <div class="form__group__area">
                        <label>Área (m²):</label>
                        <input type="number" v-model="area" required />
                    </div>
                </div>

                <div class="checkbox__container">
                    <label><input type="checkbox" v-model="areasComuns" value="piscina" /> Piscina</label>
                    <label><input type="checkbox" v-model="areasComuns" value="academia" /> Academia</label>
                    <label><input type="checkbox" v-model="areasComuns" value="churrasqueira" /> Churrasqueira</label>
                </div>

                <div class="form__group">
                    <label for="email">Email:</label>
                    <input type="email" id="email" v-model="email" placeholder="Digite o Email" required />
                </div>

                <div class="form__group">
                    <label for="telefone">Telefone:</label>
                    <input type="tel" id="telefone" v-model="telefone" placeholder="Digite o Telefone" required />
                </div>

                <button type="submit">Avaliar meu Imóvel</button>
            </form>
        </div>
        <div class="Value">
            <div v-if="loading">Carregando...</div>
            <div v-else>Preço estimado do seu imóvel: {{ responsePrice }}</div>
        </div>
    </div>

</template>
<script>
export default {
    name: 'Precificador',
    data() {
        return {
            endereco: '',
            vendaOuAluguel: '',
            novo: null,
            tipoImovel: '',
            quartos: 0,
            banheiros: 0,
            vagas: 0,
            area: null,
            areasComuns: [],
            email: '',
            telefone: '',
            responsePrice: '',
            loading: false,  // Variável para controle de carregamento
        };
    },
    methods: {
        async PostPrecificador() {
            this.loading = true;  // Flag de carregamento

            const data = {
                endereco: this.endereco,
                vendaOuAluguel: this.vendaOuAluguel,
                novo: this.novo,
                tipoImovel: this.tipoImovel,
                quartos: this.quartos,
                banheiros: this.banheiros,
                vagas: this.vagas,
                areaM2: this.area,
                areasComuns: this.areasComuns,
                email: this.email,
                telefone: this.telefone
            };

            try {
                const response = await fetch(`https://localhost:7082/Imovel/PrecificarImovel`, {
                    method: "POST",
                    headers: { 'Content-Type': 'application/json' },
                    body: JSON.stringify(data),
                });

                if (!response.ok) {
                    console.error("Erro ao calcular preço:", response.statusText);
                    this.loading = false;  // Parar o carregamento
                    return;
                }

                const responseData = await response.json();
                // Garantir que o valor 'preco' está presente na resposta
                this.responsePrice = this.formatPrice(responseData.preco || 0);
            } catch (error) {
                console.error("Erro na requisição:", error);
            } finally {
                this.loading = false;  // Parar o carregamento
            }
        },

        formatPrice(value) {
            if (!value && value !== 0) return "0";  // Verifica se o valor não é null ou undefined
            return value
                .toLocaleString("pt-BR", { style: "currency", currency: "BRL" })
                .replace("R$", "")
                .trim();
        },

    }
}
</script>


<style scoped>
.Precifier {
    width: 100%;
    height: 120vh;
}

.Value {
    width: 100%;
    height: 50vh;
    display: flex;
    align-items: center;
    justify-content: flex-end;
    font-size: 24px;
    font-weight: 600;
    color: #1A5276;
    text-align: center;
    border-radius: 8px;
    padding-right: 170px;
    margin-top: 20px;
    transition: background-color 0.3s ease;
}

.Value div {
    font-size: 36px;
    font-weight: bold;
    padding: 10px;
    border-radius: 5px;
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
}


.Precifier__Bg {
    position: relative;
    width: 100%;
    height: 450px;
    background: url('@/Images/bg.png') no-repeat center center;
    background-size: cover;
    display: flex;
    justify-content: center;
}

.property__inputs__container {
    width: 100%;
    display: flex;
}

.property-inputs {
    display: flex;
    gap: 2rem;
}

.area__group__container {
    width: 100%;
    display: flex;
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
    width: 135px;
}

.counter-controls {
    display: flex;
    align-items: center;
    gap: 0.5rem;
    flex: 1;
}

.counter-controls button {
    width: 20px;
    height: 40px;
    background-color: rgb(0, 43, 82);
    color: white;
    border: none;
    border-radius: 4px;
    font-size: 18px;
    font-weight: bold;
    cursor: pointer;
    transition: background-color 0.3s ease;
    display: flex;
    align-items: center;
    justify-content: center;
}

.counter-controls button:hover {
    background-color: #1A5276;
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

.Precifier__form {
    width: 500px;
    height: 100vh;
    background-color: #FFF;
    position: absolute;
    left: 85px;
    top: 85px;
    border-radius: 10px;
    padding: 20px;
    color: #333;
    box-shadow: rgba(0, 0, 0, 0.08) -1px 2px 20px 0px;
}

.Precifier__top {
    width: 100%;
    height: 100px;
    display: flex;
    flex-direction: column;
    gap: 20px;
    color: #333;
}

.Precifier__top h1 {
    color: #000;
    font-weight: 600;
    font-size: 28px;
}

.Precifier__top h3 {
    color: #000;
    font-weight: 600;
    font-size: 16px;
}

.form__group {
    display: flex;
    flex-direction: column;
    gap: 10px;
}

.form__group__area {
    display: flex;
    flex-direction: column;
    gap: 10px;
    width: 100%;
}

.form__group__area input {
    padding: 1rem;
    border-radius: 10px;
    border: 2px solid #ededed;
}

.form__group input {
    padding: 1rem;
    border-radius: 10px;
    border: 2px solid #ededed;
}

.select__status__container {
    width: 100%;
    display: flex;
}


.select-status {
    display: flex;
    flex-direction: column;
    justify-content: space-between;
    margin-bottom: 20px;
    height: 60px;
    flex: 1;
}

.internal-select-status {
    width: 100%;
    height: 100%;
    display: flex;
    text-align: left;
    justify-content: space-around;
}

.select-status-btn {
    flex: 1;
    margin: 0 5px;
    padding: 15px;
    font-size: 16px;
    color: white;
    border: 1px solid #ddd;
    border-radius: 10px;
    background-color: rgb(0, 43, 82);
    cursor: pointer;
    transition: 0.3s;
}

.select-status-btn.active {
    background-color: #FFF;
    border: 3px solid rgb(0, 43, 82);
    color: #000;
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

.checkbox__container {
    display: flex;
    justify-content: space-around;
    align-items: center;
    padding: 10px;
    border-radius: 5px;
}

.checkbox__container input[type="checkbox"] {
    width: 20px;
    height: 20px;
    background-color: white;
    /* Cor de fundo padrão */
    border: 2px solid rgb(0, 43, 82);
    /* Borda do checkbox */
    cursor: pointer;
}

.checkbox__container input[type="checkbox"]:checked {
    background-color: rgb(0, 43, 82);
    /* Cor de fundo quando marcado */
    border-color: rgb(0, 43, 82);
    /* Cor da borda quando marcado */
    color: white;
    /* Cor do "check" (dependendo do navegador) */
}

.checkbox__container label {
    margin-left: 10px;
    font-family: Arial, sans-serif;
    font-size: 16px;
    color: #333;
    cursor: pointer;
}

@media (max-width: 1300px) {

    .Precifier {
        height: 50vh;
    }

    .Precifier__Bg {
        display: none;
    }

    .Value {
        width: 100%;
        height: 70vh;
        display: flex;
        align-items: center;
        justify-content: center;
        font-size: 24px;
        font-weight: 600;
        color: #1A5276;
        text-align: center;
        border-radius: 8px;
        padding-right: 15px;
        padding: 20px;
        margin-top: 1000px;
        transition: background-color 0.3s ease;
    }

    .Precifier__form {
        width: 90%;
        left: 5%;
        top: 100px;
        height: auto;
    }

    .Precifier__top h1 {
        font-size: 24px;
    }

    .Precifier__top h3 {
        font-size: 14px;
    }

    .property-inputs {
        flex-direction: column;
        gap: 1rem;
    }

    .property__inputs__container {
        flex-direction: column;
    }

    .counter-group {
        flex-direction: column;
    }

    .counter {
        width: 100%;
    }

    .select__status__container {
        flex-direction: column;
    }

    .select-status {
        width: 100%;
    }

    .select-status-btn {
        margin: 0;
        padding: 12px;
        font-size: 14px;
    }

    .form__group {
        width: 100%;
    }

    .checkbox__container {
        flex-direction: column;
        align-items: flex-start;
    }

    .checkbox__container label {
        margin-left: 0;
    }

    button {
        padding: 12px 15px;
    }

    .counter-controls {
        display: flex;
        align-items: center;
        justify-content: center;
        gap: 0.5rem;
        flex: 1;
    }

    label {
        text-align: center;
    }
}

/* Para dispositivos com largura máxima de 1024px */
@media (max-width: 1024px) {
    .Precifier__form {
        width: 90%;
        left: 5%;
        top: 100px;
        height: auto;
    }

    .Precifier__top h1 {
        font-size: 22px;
    }

    .Precifier__top h3 {
        font-size: 12px;
    }

    .property-inputs {
        flex-direction: column;
        gap: 0.8rem;
    }

    .select__status__container {
        flex-direction: column;
    }

    button {
        padding: 12px 15px;
    }
}

@media (max-width: 768px) {
    .Precifier__form {
        width: 95%;
        left: 2.5%;
        top: 100px;
    }

    .Precifier__top h1 {
        font-size: 20px;
    }

    .Precifier__top h3 {
        font-size: 12px;
    }

    .property-inputs {
        flex-direction: column;
        gap: 0.8rem;
    }
}
</style>
