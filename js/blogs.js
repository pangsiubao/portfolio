const lijst = document.querySelector("#blogs-lijst");
const statusMelding = document.querySelector("#status");
const sorteerSelect = document.querySelector("#sorteer");

let alleBlogs = [];

const formatteerDatum = (datum) => {
  return new Date(datum).toLocaleDateString("nl-NL", {
    day: "numeric",
    month: "long",
    year: "numeric",
    timeZone: "UTC", 
  });
};

const maakBlogKaart = (blog) => {
  const item = document.createElement("li");

  const kaart = document.createElement("article");
  kaart.classList.add("card");

  const titel = document.createElement("h2");
  titel.textContent = blog.titel;

  const beschrijving = document.createElement("p");
  beschrijving.textContent = blog.beschrijving;

  const meta = document.createElement("footer");
  meta.classList.add("card-meta");

  const datum = document.createElement("time");
  datum.dateTime = blog.datum;
  datum.textContent = formatteerDatum(blog.datum);

  meta.append(datum);
  kaart.append(titel, beschrijving, meta);
  item.append(kaart);
  return item;
};

const toonBlogs = (blogs) => {
  lijst.innerHTML = "";
  blogs.forEach((blog) => {
    lijst.append(maakBlogKaart(blog));
  });
};


const sorteerBlogs = (blogs, volgorde) => {
  if (volgorde === "nieuw") {
    blogs.sort((a, b) => new Date(b.datum) - new Date(a.datum));
  } else {
    blogs.sort((a, b) => new Date(a.datum) - new Date(b.datum));
  }
};

const updateOverzicht = () => {
  sorteerBlogs(alleBlogs, sorteerSelect.value);
  toonBlogs(alleBlogs);
};

const laadBlogs = () => {
  fetch("data/blogs.json")
    .then((response) => {
      if (!response.ok) {
        throw new Error("Bestand niet gevonden");
      }
      return response.json();
    })
    .then((data) => {
      alleBlogs = data;
      statusMelding.textContent = "";
      updateOverzicht();
    })
    .catch((fout) => {
      console.error("Blogs laden mislukt:", fout);
      statusMelding.textContent =
        "De blogs konden niet worden geladen. Ververs de pagina om het opnieuw te proberen.";
    });
};

sorteerSelect.addEventListener("change", updateOverzicht);
laadBlogs();