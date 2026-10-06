const knoppen = document.querySelectorAll('.meer-knop');

const toonTekst = (knop) => {
    const kaart = knop.closest('.card');
    const tekst = kaart.querySelector('.blog-meer');
    const isOpen = knop.getAttribute('aria-expanded') === 'true';

    if (isOpen) {
        tekst.hidden = true;
        knop.setAttribute('aria-expanded', 'false');
        knop.textContent = 'Lees meer';
    }
    else {
        tekst.hidden = false;
        knop.setAttribute('aria-expanded', 'true');
        knop.textContent = 'Lees minder';
    }
};

knoppen.forEach((knop) => {
    knop.addEventListener('click', () => {
        toonTekst(knop);
    });
});