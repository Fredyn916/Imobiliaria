<template>
    <div class="container">
        <h1>Filtros de Produtos</h1>
        <div class="filter-container">
            <label for="categoryFilter">Categoria:</label>
            <select id="categoryFilter" v-model="selectedCategory" class="filter-select">
                <option value="">Todas</option>
                <option value="iphone">Apple</option>
                <option value="Samsung">Samsung</option>
            </select>
        </div>

        <div class="filter-container">
            <label for="searchBar">Pesquisar Produto:</label>
            <input type="text" id="searchBar" v-model="searchQuery" @input="filterProducts"
                placeholder="Digite o nome do produto..." class="filter-input" />
        </div>

        <ul class="product-list">
            <li v-for="product in filteredProducts" :key="product.id" class="product-item">
                <strong>{{ product.nome }}</strong><br>
                Preço: R$ {{ product.preco.toFixed(2) }}<br>
                Descrição: {{ product.descricao }}<br>
                Quantidade em estoque: {{ product.quantidadeEmEstoque }} unidades<br>
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
            products: [],
            searchQuery: "",
            selectedCategory: "",
            filteredProducts: []
        };
    },
    methods: {
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
                this.filteredProducts = data;
            } catch (error) {
                console.error('Erro ao carregar produtos:', error);
            }
        },

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
    watch: {
        selectedCategory() {
            this.filterProducts();
        },
        searchQuery() {
            this.filterProducts();
        }
    },
    mounted() {
        this.fetchProducts();
    }
};
</script>

<style scoped>
.container {
    font-family: 'Arial', sans-serif;
    padding: 20px;
    background-color: #f9f9f9;
    max-width: 800px;
    margin: 0 auto;
}

h1 {
    text-align: center;
    color: #333;
    margin-bottom: 20px;
}

.filter-container {
    margin-bottom: 20px;
    display: flex;
    flex-direction: column;
}

label {
    font-weight: bold;
    color: #333;
    margin-bottom: 5px;
}

.filter-select,
.filter-input {
    padding: 10px;
    border: 1px solid #ccc;
    border-radius: 5px;
    font-size: 16px;
}

.filter-select {
    cursor: pointer;
}

.product-list {
    list-style-type: none;
    padding: 0;
}

.product-item {
    background-color: #fff;
    padding: 15px;
    margin-bottom: 10px;
    border-radius: 5px;
    box-shadow: 0 2px 4px rgba(0, 0, 0, 0.1);
}
.product-item:hover {
    cursor: pointer;
}
.product-item strong {
    color: #333;
}

@media (max-width: 600px) {
    .container {
        padding: 10px;
    }

    .filter-select,
    .filter-input {
        width: 100%;
        box-sizing: border-box;
    }
}
</style>