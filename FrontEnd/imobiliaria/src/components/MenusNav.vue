<template>
    <header>
        <nav>
            <ul class="Nav__ul">
                <div class="logo">
                    <RouterLink to="/"><img src="@/Images/logo.png" alt="logo" width="20px"></RouterLink>
                </div>
                <RouterLink to="ViewImovel" class="Nav__Li">Comprar</RouterLink>
                <RouterLink to="ViewImovel" class="Nav__Li">Alugar</RouterLink>
                <li class="Nav__Li">Contato</li>
                <li class="Nav__Li">Sobre nos</li>
            </ul>
        </nav>
    </header>

</template>

<script>
export default {
    name: 'MenusNav'
}
</script>

<style scoped>
.Nav__ul {
    display: flex;
    gap: 20px;
}

.Nav__Li {
    color: #333;
    display: inline-block;
    padding-bottom: 2px;
    position: relative;
    gap: 20px;
}

.Nav__Li:hover {
    cursor: pointer;
}

.Nav__Li:hover::after {
    content: "";
    position: absolute;
    bottom: 0;
    left: 0;
    width: 100%;
    height: 2px;
    background-color: black;
    cursor: pointer;
}

.logo {
    display: block;
}

@media (width: 768px) {

    .Nav__ul {
        display: flex;
        flex-direction: column;
        gap: 20px;
    }
}

@media (max-width: 1280px) {
    .logo {
        display: none;
    }

    .Nav__ul {
        display: flex;
        flex-direction: column;
        gap: 20px;
    }

    .Nav__Li:hover::after {
        display: none;
    }
}
</style>