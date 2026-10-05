const lijst = document.querySelector("#projecten-lijst");
const statusMelding = document.querySelector("#status");
const sorteerSelect = document.querySelector("#sorteer");
 
let alleProjecten = [];
 
const maakProjectKaart = (project) => {
  const item = document.createElement("li");
  const kaart = document.createElement("article");
  kaart.classList.add("card");
 
  const titel = document.createElement("h2");
  titel.textContent = project.titel;
 
  const beschrijving = document.createElement("p");
  beschrijving.textContent = project.beschrijving;
 
  const meta = document.createElement("footer");
  meta.classList.add("card-meta");
 
  const jaar = document.createElement("time");
  jaar.dateTime = String(project.jaar);
  jaar.textContent = project.jaar;
 
  meta.append(`${project.taal} · `, jaar);
  kaart.append(titel, beschrijving, meta);
  item.append(kaart);
  return item;
};
 
const toonProjecten = (projecten) => {
  lijst.replaceChildren();
  projecten.forEach((project) => lijst.append(maakProjectKaart(project)));
};
 
const sorteerProjecten = (projecten, volgorde) =>
  [...projecten].sort((a, b) =>
    volgorde === "nieuw" ? b.jaar - a.jaar : a.jaar - b.jaar
  );
 
const updateOverzicht = () => {
  toonProjecten(sorteerProjecten(alleProjecten, sorteerSelect.value));
};
 
const laadProjecten = async () => {
  try {
    const response = await fetch("data/projecten.json");
    if (!response.ok) throw new Error(`HTTP-fout: ${response.status}`);
    alleProjecten = await response.json();
    statusMelding.textContent = "";
    updateOverzicht();
  } catch (fout) {
    console.error("Projecten laden mislukt:", fout);
    statusMelding.textContent =
      "De projecten konden niet worden geladen. Ververs de pagina om het opnieuw te proberen.";
  }
};
 
sorteerSelect.addEventListener("change", updateOverzicht);
laadProjecten();