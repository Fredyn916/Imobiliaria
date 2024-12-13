<template>
    <section class="sobre__nos">
        <h1> 1. Quem somos</h1>
        <p> <img src="https://res.cloudinary.com/fredmarques/image/upload/v1734056496/LogoSweetHome_tzwyjv.png"
                alt="ImagemDoSite" width="50px"> Escrito por SweetHome</p>
        <p>Atualizado há mais de um ano</p>
        <hr />

        <p>O Portal Sweet Home é um marketplace que oferece serviços de anúncios a mais de mil imobiliárias em todo o
            país, com um milhão de imóveis oferecidos para venda e aluguel. O Portal Casa Mineira é uma empresa
            independente da Casa Mineira, maior e mais tradicional imobiliária de Belo Horizonte (MG), com 39 anos de
            história e líder em compra e venda e aluguel de imóveis residenciais em Minas Gerais.</p>

        <p>Em março de 2021, ganhamos ainda mais relevância ao nos juntar ao QuintoAndar, maior plataforma digital de
            moradia do país. Juntas, as companhias aliam tecnologia, dados, conhecimento de mercado e apoio a clientes
            para levar a melhor experiência para quem quer alugar, comprar ou vender um imóvel residencial.</p>

        <p>Conheça nossos planos de benefícios, acesse nossa página principal.</p>

        <p>Sweet Home LTDA<br>
            CNPJ: 00.000.000/0001-00<br>
            Rua California, 200 - Sion, Belo Horizonte/MG - 30315-500</p>
    </section>
</template>

<script>
export default {
    name: 'SobreNos'
};
</script>
<style scoped>
/* Estilos para o container da seção "Sobre Nós" */
.sobre__nos {
    max-width: 800px;
    /* Define a largura máxima do container como 800px */
    margin: 50px auto;
    /* Adiciona uma margem de 50px no topo e na parte inferior e centraliza o container horizontalmente */
    padding: 20px;
    /* Adiciona um preenchimento interno de 20px ao redor do conteúdo */
    background-color: #fff;
    /* Define o fundo do container como branco */
    border-radius: 8px;
    /* Aplica bordas arredondadas com raio de 8px */
    font-family: "Funnel Display", sans-serif;
    /* Define a fonte do texto como "Funnel Display", com uma fonte alternativa sans-serif caso não esteja disponível */
}

/* Estilos para o título da seção "Sobre Nós" (h1) */
.sobre__nos h1 {
    font-size: 2rem;
    /* Define o tamanho da fonte como 2rem */
    color: #333;
    /* Define a cor do texto como um tom de cinza escuro */
    text-align: center;
    /* Centraliza o texto */
    margin-bottom: 20px;
    /* Adiciona uma margem inferior de 20px */
}

/* Estilos para os parágrafos dentro da seção "Sobre Nós" */
.sobre__nos p {
    line-height: 1.6;
    /* Define a altura da linha como 1.6, proporcionando mais espaçamento entre as linhas de texto */
    color: #555;
    /* Define a cor do texto como um tom de cinza médio */
    margin-bottom: 10px;
    /* Adiciona uma margem inferior de 10px entre os parágrafos */
}

/* Estilos para a linha horizontal (hr) dentro da seção "Sobre Nós" */
.sobre__nos hr {
    border: 0;
    /* Remove a borda padrão */
    height: 1px;
    /* Define a altura da linha como 1px */
    background-color: #e0e0e0;
    /* Define a cor da linha como um tom de cinza claro */
    margin: 20px 0;
    /* Adiciona uma margem de 20px na parte superior e inferior da linha */
}
</style>
