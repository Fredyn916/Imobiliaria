<template>
    <div>
        <h1>Filtros de Produtos</h1>

        <!-- Filtro por categoria (Dropdown) -->
        <div>
            <label for="categoryFilter">Categoria:</label>
            <select id="categoryFilter" v-model="selectedCategory" @change="filterProducts">
                <option value="">Todas</option>
                <option value="iphone">Apple</option>
                <option value="Samsung">Samsung</option>
                <!-- Se tiver outras categorias, adicione mais opções -->
            </select>
        </div>

        <!-- Barra de Pesquisa para nome de produto -->
        <div>
            <label for="searchBar">Pesquisar Produto:</label>
            <input type="text" id="searchBar" v-model="searchQuery" @input="filterProducts"
                placeholder="Digite o nome do produto..." />
        </div>

        <!-- Lista de Produtos -->
        <ul>
            <li v-for="product in filteredProducts" :key="product.id">
                <strong>{{ product.nome }}</strong><br>
                Preço: R$ {{ product.preco.toFixed(2) }}<br>
                Descrição: {{ product.descricao }}<br>
                Quantidade em estoque: {{ product.quantidadeEmEstoque }} unidades<br>
                Fornecedor: {{ product.fornecedorname.nome }}<br>
                FornecedorId: {{ product.fornecedorId }}
            </li>
        </ul>
    </div>
</template>

<script>
export default {
    name: 'ViewImovel',
    data() {
        return {
            products: [],            // Array para armazenar todos os produtos
            searchQuery: "",         // Termo de pesquisa
            selectedCategory: "",    // Categoria selecionada para filtro
            filteredProducts: []     // Array para armazenar produtos filtrados
        };
    },
    methods: {
        // Função para buscar produtos da API
        async fetchProducts() {
            const apiUrl = "https://localhost:7248/Produto/visualizar-produto";

            try {
                const response = await fetch(apiUrl, {
                    method: "GET",
                    headers: {
                        Accept: "application/json",
                    },
                });

                if (!response.ok) {
                    throw new Error('Erro ao buscar produtos.');
                }

                const data = await response.json();
                this.products = data;
                this.filteredProducts = data; // Inicializa com todos os produtos
            } catch (error) {
                console.error('Erro ao carregar produtos:', error);
            }
        },

        // Função para filtrar produtos
        filterProducts() {
            this.filteredProducts = this.products.filter((product) => {
                const matchesCategory = this.selectedCategory
                    ? product.nome.toLowerCase().includes(this.selectedCategory.toLowerCase())
                    : true;
                const matchesSearch = product.nome.toLowerCase().includes(this.searchQuery.toLowerCase());

                return matchesCategory && matchesSearch;
            });
        }
    },
    mounted() {
        // Chama a função para buscar produtos ao montar o componente
        this.fetchProducts();
    }
};
</script>

<style scoped>
/* Adicione qualquer estilo adicional aqui */
</style>
