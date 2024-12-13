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
                    <div class="select__status">
                        <label for="operacao">Tipo de operação?</label>
                        <div class="internal__select__status">
                            <button type="button" class="select__status__btn"
                                :class="{ active: vendaOuAluguel === 'Venda' }"
                                @click="vendaOuAluguel = 'Venda'">Venda</button>
                            <button type="button" class="select__status__btn"
                                :class="{ active: vendaOuAluguel === 'Aluguel' }"
                                @click="vendaOuAluguel = 'Aluguel'">Aluguel</button>
                        </div>
                    </div>

                    <div class="select__status">
                        <label for="novo">Seu Imóvel é novo?</label>
                        <div class="internal__select__status">
                            <button type="button" class="select__status__btn" :class="{ active: novo === true }"
                                @click="novo = true">Sim</button>
                            <button type="button" class="select__status__btn" :class="{ active: novo === false }"
                                @click="novo = false">Não</button>
                        </div>
                    </div>
                </div>

                <div class="select__status">
                    <label for="tipoImovel">Tipo de Imóvel?</label>
                    <div class="internal__select__status">
                        <button type="button" class="select__status__btn"
                            :class="{ active: tipoImovel === 'Apartamento' }"
                            @click="tipoImovel = 'Apartamento'">Apartamento</button>
                        <button type="button" class="select__status__btn" :class="{ active: tipoImovel === 'Casa' }"
                            @click="tipoImovel = 'Casa'">Casa</button>
                    </div>
                </div>

                <div class="property__inputs__container">
                    <div class="property__inputs">
                        <div class="counter__group">
                            <div class="counter">
                                <label>Quartos</label>
                                <div class="counter__controls">
                                    <button type="button" @click="quartos = Math.max(quartos - 1, 0)">-</button>
                                    <input type="number" v-model="quartos" readonly />
                                    <button type="button" @click="quartos++">+</button>
                                </div>
                            </div>
                            <div class="counter">
                                <label>Banheiros</label>
                                <div class="counter__controls">
                                    <button type="button" @click="banheiros = Math.max(banheiros - 1, 0)">-</button>
                                    <input type="number" v-model="banheiros" readonly />
                                    <button type="button" @click="banheiros++">+</button>
                                </div>
                            </div>
                            <div class="counter">
                                <label>Garagens</label>
                                <div class="counter__controls">
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
/* Estilo para o container principal da tela de precificação */
.Precifier {
    width: 100%;
    /* Largura total */
    height: auto;
    /* Altura automatica para a altura da tela */
    padding-bottom: 100px;
    /* padding para espaçamento */
}

/* Estilo para o bloco de valor na tela */
.Value {
    width: 100%;
    /* Largura total */
    height: 50vh;
    /* Altura 50% da altura da tela */
    display: flex;
    /* Usando flexbox */
    align-items: center;
    /* Alinha verticalmente */
    justify-content: flex-end;
    /* Alinha para a direita */
    font-size: 24px;
    /* Tamanho da fonte */
    font-weight: 600;
    /* Peso da fonte */
    color: #1A5276;
    /* Cor do texto */
    text-align: center;
    /* Alinhamento centralizado */
    border-radius: 8px;
    /* Bordas arredondadas */
    padding-right: 170px;
    /* Espaço à direita */
    margin-top: 20px;
    /* Margem superior */
    transition: background-color 0.3s ease;
    /* Transição suave para a cor de fundo */
}

/* Estilo para os elementos dentro do bloco de valor */
.Value div {
    font-size: 36px;
    /* Tamanho maior da fonte */
    font-weight: bold;
    /* Fonte em negrito */
    padding: 10px;
    /* Espaçamento interno */
    border-radius: 5px;
    /* Bordas arredondadas */
    box-shadow: 0 4px 6px rgba(0, 0, 0, 0.1);
    /* Sombra sutil */
}

/* Estilo de fundo da tela de precificação */
.Precifier__Bg {
    position: relative;
    /* Posicionamento relativo */
    width: 100%;
    /* Largura total */
    height: 450px;
    /* Altura fixa */
    background: url('https://res.cloudinary.com/fredmarques/image/upload/v1734056495/BgPrecificador_z1w3ul.png') no-repeat center center;
    /* Imagem de fundo */
    background-size: cover;
    /* Cobre toda a área */
    display: flex;
    /* Flexbox */
    justify-content: center;
    /* Centraliza o conteúdo */
}

/* Estilo para o container de inputs das propriedades */
.property__inputs__container {
    width: 100%;
    /* Largura total */
    display: flex;
    /* Flexbox */
}

/* Estilo para o grupo de inputs das propriedades */
.property__inputs {
    display: flex;
    /* Flexbox */
    gap: 2rem;
    /* Espaçamento entre os itens */
}

/* Estilo para o grupo de áreas */
.area__group__container {
    width: 100%;
    /* Largura total */
    display: flex;
    /* Flexbox */
}

/* Estilo para os grupos de contador e área */
.counter__group,
.area-group {
    display: flex;
    /* Flexbox */
    flex-wrap: wrap;
    /* Permite quebra de linha */
    gap: 1.5rem;
    /* Espaçamento entre os itens */
}

/* Estilo para os elementos de contador e área */
.counter,
.area-input {
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza em coluna */
    width: 135px;
    /* Largura fixa */
}

/* Estilo para os controles do contador */
.counter__controls {
    display: flex;
    /* Flexbox */
    align-items: center;
    /* Alinha verticalmente */
    gap: 0.5rem;
    /* Espaçamento entre os controles */
    flex: 1;
    /* Preenche o espaço disponível */
}

/* Estilo para os botões dentro dos controles de contador */
.counter__controls button {
    width: 20px;
    /* Largura do botão */
    height: 40px;
    /* Altura do botão */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo */
    color: white;
    /* Cor do texto */
    border: none;
    /* Sem borda */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 18px;
    /* Tamanho da fonte */
    font-weight: bold;
    /* Fonte em negrito */
    cursor: pointer;
    /* Cursor de ponteiro */
    transition: background-color 0.3s ease;
    /* Transição para a cor de fundo */
    display: flex;
    /* Flexbox */
    align-items: center;
    /* Alinha o conteúdo */
    justify-content: center;
    /* Alinha o conteúdo */
}

/* Efeito de hover para os botões de controle */
.counter__controls button:hover {
    background-color: #1A5276;
    /* Cor de fundo no hover */
}

/* Estilo para os inputs de tipo number */
.property__inputs input[type="number"] {
    width: 60px;
    /* Largura do input */
    text-align: center;
    /* Alinha o texto ao centro */
    border: 1px solid #ddd;
    /* Borda do input */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 16px;
    /* Tamanho da fonte */
    padding: 5px;
    /* Espaçamento interno */
}

/* Estilo para os inputs de tipo text */
.property__inputs input[type="text"] {
    width: 60px;
    /* Largura do input */
    text-align: center;
    /* Alinha o texto ao centro */
    border: 1px solid #ddd;
    /* Borda do input */
    border-radius: 4px;
    /* Bordas arredondadas */
    font-size: 16px;
    /* Tamanho da fonte */
    padding: 5px;
    /* Espaçamento interno */
}

/* Estilo para o wrapper dos inputs */
.input-wrapper {
    display: flex;
    /* Flexbox */
    align-items: center;
    /* Alinha verticalmente */
    gap: 0.5rem;
    /* Espaçamento entre os itens */
}

/* Estilo para o texto ao lado dos inputs */
.property__inputs span {
    font-size: 1rem;
    /* Tamanho da fonte */
}

/* Estilo para o formulário de precificação */
.Precifier__form {
    width: 500px;
    /* Largura do formulário */
    height: auto;
    /* Altura da tela */
    background-color: #FFF;
    /* Cor de fundo */
    position: absolute;
    /* Posicionamento absoluto */
    left: 85px;
    /* Posição à esquerda */
    top: 85px;
    /* Posição superior */
    border-radius: 10px;
    /* Bordas arredondadas */
    padding: 20px;
    /* Espaçamento interno */
    color: #333;
    /* Cor do texto */
    box-shadow: rgba(0, 0, 0, 0.08) -1px 2px 20px 0px;
    /* Sombra */
}

/* Estilo para o topo do formulário */
.Precifier__top {
    width: 100%;
    /* Largura total */
    height: 100px;
    /* Altura do topo */
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza em coluna */
    gap: 20px;
    /* Espaçamento entre os elementos */
    color: #333;
    /* Cor do texto */
}

/* Estilo para o título principal do topo */
.Precifier__top h1 {
    color: #000;
    /* Cor do texto */
    font-weight: 600;
    /* Peso da fonte */
    font-size: 28px;
    /* Tamanho da fonte */
}

/* Estilo para o subtítulo do topo */
.Precifier__top h3 {
    color: #000;
    /* Cor do texto */
    font-weight: 600;
    /* Peso da fonte */
    font-size: 16px;
    /* Tamanho da fonte */
}

/* Estilo para os grupos de formulário */
.form__group {
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza em coluna */
    gap: 10px;
    /* Espaçamento entre os elementos */
}

/* Estilo para os grupos de área do formulário */
.form__group__area {
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza em coluna */
    gap: 10px;
    /* Espaçamento entre os elementos */
    width: 100%;
    /* Largura total */
}

/* Estilo para os inputs dentro dos grupos de área */
.form__group__area input {
    padding: 1rem;
    /* Espaçamento interno */
    border-radius: 10px;
    /* Bordas arredondadas */
    border: 2px solid #ededed;
    /* Borda do input */
}

/* Estilo para os inputs no grupo de formulário */
.form__group input {
    padding: 1rem;
    /* Espaçamento interno */
    border-radius: 10px;
    /* Bordas arredondadas */
    border: 2px solid #ededed;
    /* Borda do input */
}

/* Estilo para o container de botões de status */
.select__status__container {
    width: 100%;
    /* Largura total */
    display: flex;
    /* Flexbox */
}

/* Estilo para o grupo de seleção de status */
.select__status {
    display: flex;
    /* Flexbox */
    flex-direction: column;
    /* Organiza em coluna */
    justify-content: space-between;
    /* Espaço entre os itens */
    margin-bottom: 20px;
    /* Margem inferior */
    height: 60px;
    /* Altura fixa */
    flex: 1;
    /* Preenche o espaço disponível */
}

/* Estilo para os botões de status */
.internal__select__status {
    width: 100%;
    /* Largura total */
    height: 100%;
    /* Altura total */
    display: flex;
    /* Flexbox */
    text-align: left;
    /* Alinha o texto à esquerda */
    justify-content: space-around;
    /* Espaço entre os itens */
}

/* Estilo para os botões de status */
.select__status__btn {
    flex: 1;
    /* Preenche o espaço disponível */
    margin: 0 5px;
    /* Margem entre os botões */
    padding: 15px;
    /* Espaçamento interno */
    font-size: 16px;
    /* Tamanho da fonte */
    color: white;
    /* Cor do texto */
    border: 1px solid #ddd;
    /* Borda do botão */
    border-radius: 10px;
    /* Bordas arredondadas */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo */
    cursor: pointer;
    /* Cursor de ponteiro */
    transition: 0.3s;
    /* Transição suave */
}

/* Estilo para o botão ativo */
.select__status__btn.active {
    background-color: #FFF;
    /* Cor de fundo ativa */
    border: 3px solid rgb(0, 43, 82);
    /* Borda ativa */
    color: #000;
    /* Cor do texto ativa */
}

/* Estilo para os botões no geral */
button {
    padding: 10px 20px;
    /* Espaçamento interno */
    margin: 10px 0;
    /* Margem */
    background-color: rgb(0, 43, 82);
    /* Cor de fundo */
    color: white;
    /* Cor do texto */
    border: none;
    /* Sem borda */
    border-radius: 4px;
    /* Bordas arredondadas */
    cursor: pointer;
    /* Cursor de ponteiro */
    transition: 0.3s;
    /* Transição suave */
    width: 100%;
    /* Largura total */
}

/* Estilo para os botões desabilitados */
button:disabled {
    background-color: #ccc;
    /* Cor de fundo desabilitada */
    cursor: not-allowed;
    /* Cursor desabilitado */
}

/* Efeito de hover para os botões */
button:hover {
    background-color: #1A5276;
    /* Cor de fundo no hover */
    transform: scale(1.05);
    /* Leve aumento de tamanho */
}

/* Estilo para o container de checkboxes */
.checkbox__container {
    display: flex;
    /* Flexbox */
    justify-content: space-around;
    /* Espaçamento entre os itens */
    align-items: center;
    /* Alinha verticalmente */
    padding: 10px;
    /* Espaçamento interno */
    border-radius: 5px;
    /* Bordas arredondadas */
}

/* Estilo para os checkboxes */
.checkbox__container input[type="checkbox"] {
    width: 20px;
    /* Largura do checkbox */
    height: 20px;
    /* Altura do checkbox */
    background-color: white;
    /* Cor de fundo */
    border: 2px solid rgb(0, 43, 82);
    /* Borda do checkbox */
    cursor: pointer;
    /* Cursor de ponteiro */
}

/* Estilo para o estado checado do checkbox */
.checkbox__container input[type="checkbox"]:checked {
    background-color: rgb(0, 43, 82);
    /* Cor de fundo quando marcado */
    border-color: rgb(0, 43, 82);
    /* Cor da borda quando marcado */
    color: white;
    /* Cor do check */
}

/* Estilo para os rótulos dos checkboxes */
.checkbox__container label {
    margin-left: 10px;
    /* Espaçamento à esquerda */
    font-family: Arial, sans-serif;
    /* Fonte */
    font-size: 16px;
    /* Tamanho da fonte */
    color: #333;
    /* Cor do texto */
    cursor: pointer;
    /* Cursor de ponteiro */
}

/* Media queries para dispositivos com largura máxima de 1300px */
@media (max-width: 1300px) {
    .Precifier {
        height: 50vh;
        /* Reduz a altura */
    }

    .Precifier__Bg {
        display: none;
        /* Oculta o fundo */
    }

    .Value {
        width: 100%;
        /* Largura total */
        height: 70vh;
        /* Altura menor */
        display: flex;
        /* Flexbox */
        align-items: center;
        /* Alinha verticalmente */
        justify-content: center;
        /* Centraliza o conteúdo */
        font-size: 24px;
        /* Tamanho da fonte */
        font-weight: 600;
        /* Peso da fonte */
        color: #1A5276;
        /* Cor do texto */
        text-align: center;
        /* Alinhamento central */
        border-radius: 8px;
        /* Bordas arredondadas */
        padding-right: 15px;
        /* Espaçamento à direita */
        padding: 20px;
        /* Espaçamento interno */
        margin-top: 1000px;
        /* Margem superior */
        transition: background-color 0.3s ease;
        /* Transição suave */
    }

    .Precifier__form {
        width: 90%;
        /* Largura do formulário */
        left: 5%;
        /* Posição à esquerda */
        top: 100px;
        /* Posição superior */
        height: auto;
        /* Altura automática */
    }

    .Precifier__top h1 {
        font-size: 24px;
        /* Tamanho menor do título */
    }

    .Precifier__top h3 {
        font-size: 14px;
        /* Tamanho menor do subtítulo */
    }

    .property__inputs {
        flex-direction: column;
        /* Alinha os inputs em coluna */
        gap: 1rem;
        /* Espaçamento entre os itens */
    }

    .property__inputs__container {
        flex-direction: column;
        /* Alinha os inputs em coluna */
    }

    .counter__group {
        flex-direction: column;
        /* Alinha os contadores em coluna */
    }

    .counter {
        width: 100%;
        /* Largura total */
    }

    .select__status__container {
        flex-direction: column;
        /* Alinha os botões em coluna */
    }

    .select__status {
        width: 100%;
        /* Largura total */
    }

    .select__status__btn {
        margin: 0;
        /* Remove margem */
        padding: 12px;
        /* Ajusta o padding */
        font-size: 14px;
        /* Tamanho da fonte */
    }

    .form__group {
        width: 100%;
        /* Largura total */
    }

    .checkbox__container {
        flex-direction: column;
        /* Alinha os checkboxes em coluna */
        align-items: flex-start;
        /* Alinha à esquerda */
    }

    .checkbox__container label {
        margin-left: 0;
        /* Remove margem */
    }

    button {
        padding: 12px 15px;
        /* Ajusta o padding */
    }

    .counter__controls {
        display: flex;
        /* Flexbox */
        align-items: center;
        /* Alinha verticalmente */
        justify-content: center;
        /* Centraliza o conteúdo */
        gap: 0.5rem;
        /* Espaçamento */
        flex: 1;
        /* Preenche o espaço disponível */
    }

    label {
        text-align: center;
        /* Centraliza o texto */
    }
}

/* Media queries para dispositivos com largura máxima de 1024px */
@media (max-width: 1024px) {
    .Precifier__form {
        width: 90%;
        /* Largura do formulário */
        left: 5%;
        /* Posição à esquerda */
        top: 100px;
        /* Posição superior */
        height: auto;
        /* Altura automática */
    }

    .Precifier__top h1 {
        font-size: 22px;
        /* Tamanho menor do título */
    }

    .Precifier__top h3 {
        font-size: 12px;
        /* Tamanho menor do subtítulo */
    }

    .property__inputs {
        flex-direction: column;
        /* Alinha os inputs em coluna */
        gap: 0.8rem;
        /* Espaçamento entre os itens */
    }

    .select__status__container {
        flex-direction: column;
        /* Alinha os botões em coluna */
    }

    button {
        padding: 12px 15px;
        /* Ajusta o padding */
    }
}

/* Media queries para dispositivos com largura máxima de 768px */
@media (max-width: 768px) {
    .Precifier__form {
        width: 95%;
        /* Largura do formulário */
        left: 2.5%;
        /* Posição à esquerda */
        top: 100px;
        /* Posição superior */
    }

    .Precifier__top h1 {
        font-size: 20px;
        /* Tamanho menor do título */
    }

    .Precifier__top h3 {
        font-size: 12px;
        /* Tamanho menor do subtítulo */
    }

    .property__inputs {
        flex-direction: column;
        /* Alinha os inputs em coluna */
        gap: 0.8rem;
        /* Espaçamento entre os itens */
    }
}
</style>
