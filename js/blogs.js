const lijst = document.querySelector('#blogs-lijst');
const statusMelding = document.querySelector('#status');
const sorteerSelect = document.querySelector('#sorteer');

let alleBlogs = [];

const maakBlogKaart = (blog) => {
    const item = document.createElement('li');

    const kaart = document.createElement('article');
    kaart.classList.add('card');

    const titel = document.createElement('h2');
    titel.textContent = blog.titel;

    const beschrijving = document.createElement('p');
    beschrijving.textContent = blog.beschrijving;

    const meer = document.createElement('p');
    meer.classList.add('blog-meer');
    meer.textContent = blog.meer;
    meer.hidden = true;

    const knop = document.createElement('button');
    knop.type = 'button';
    knop.classList.add('meer-knop');
    knop.setAttribute('aria-expanded', 'false');
    knop.textContent = 'Lees meer';
    knop.addEventListener('click', () => toonTekst(knop));

    const meta = document.createElement('footer');
    meta.classList.add('card-meta');

    const jaar = document.createElement('time');
    jaar.textContent = blog.jaar;
    meta.append(jaar);

    kaart.append(titel, beschrijving, meer, knop, meta);
    item.append(kaart);
    return item;
};

const toonBlogs = (blogs) => {
    lijst.innerHTML = '';
    blogs.forEach((blog) => {
        lijst.append(maakBlogKaart(blog));
    });
};

const sorteerBlogs = (blogs, volgorde) => {
    if (volgorde === 'nieuw') {
        blogs.sort((a, b) => b.jaar - a.jaar);
    } else {
        blogs.sort((a, b) => a.jaar - b.jaar);
    }
};

const updateOverzicht = () => {
    sorteerBlogs(alleBlogs, sorteerSelect.value);
    toonBlogs(alleBlogs);
};

const laadBlogs = () => {
    fetch('data/blogs.json')
        .then((response) => {
            if (!response.ok) {
                throw new Error('Bestand niet gevonden');
            }
            return response.json();
        })
        .then((data) => {
            alleBlogs = data;
            statusMelding.textContent = '';
            updateOverzicht();
        })
        .catch((fout) => {
            console.error('Blogs laden mislukt:', fout);
            statusMelding.textContent =
                'De blogs konden niet worden geladen. Ververs de pagina om het opnieuw te proberen.';
        });
};

const toonTekst = (knop) => {
    const kaart = knop.closest('.card');
    const tekst = kaart.querySelector('.blog-meer');
    const isOpen = knop.getAttribute('aria-expanded') === 'true';

    if (isOpen) {
        tekst.hidden = true;
        knop.setAttribute('aria-expanded', 'false');
        knop.textContent = 'Lees meer';
    } else {
        tekst.hidden = false;
        knop.setAttribute('aria-expanded', 'true');
        knop.textContent = 'Lees minder';
    }
};

sorteerSelect.addEventListener('change', updateOverzicht);
laadBlogs();