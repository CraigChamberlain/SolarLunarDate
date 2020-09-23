---
layout: q-n-a
title: Sculptures
redirect_from: sculptures.html
gallery: 
  - name: "Lead Oblong, Allonby, 2010 (2/2)"
    image: 10_BC-01-c.jpg
  - name: "Lead Disk, Allonby, 2010 (2/2)"
    image: 10_BC-02-c.jpg
  - name: "Truncated Pyramid, Allonby, 2013-2-27 (March 8th pm 2013) Prototype I (1/1)"
    image: 13_BC-03,1-01-c.jpg
  - name: "Truncated Pyramid, Allonby, 2013-2-27 (March 8th pm 2013) Prototype II (1/1)"
    image: 13_BC-04-02-c.jpg
  - name: "Lead Disk, Allonby, 2013-2-27 (March 8th pm 2013) (1/2)"
    image: 13_BC-05-01-c.jpg
---
<section class="section" id="example_work">
<h2 class="title">Example Work</h2>
<ul class="gallery 2x2 columns is-multiline is-vcentered">
{% for work in page.gallery %}
  <li class="column is-half">
    <picture>
      {% assign url = '/assets/images/' | append: work.image | replace: '.jpg', '' | append: '_700'  | relative_url %}
      <source srcset="{{ url }}.webp" type="image/webp">
      <source srcset="{{ url }}.jpg" type="image/jpeg"> 
      <img src="{{ url }}.jpg"/>
    </picture>
    
    <h3>{{ work.name }}</h3>
  </li>
{% endfor%}
</ul>
</section>
<section class="section" id="exhibitions">
<h2 class="title">Exhibitions</h2>
<picture>
  <source srcset="{{'/assets/images/IMG_1254_3x2_1800.webp' | relative_url }}" type="image/webp">
  <source srcset="{{'/assets/images/IMG_1254_3x2_1800.jpg' | relative_url }}"> 
  <img src="{{'/assets/images/IMG_1254_3x2_1800.jpg' | relative_url }}" alt="Artist at Exhibition"/>
</picture>

<ol>
  <li>
    <a href="{{'/assets/images/20130405CrownGalleryCarlisle-CumberlandNews-Friday5thApri2003_3x2_1800.jpg' | relative_url }}" target="_blank"><h3>Time and Tide @ Crown Gallery, Carlisle - 06/04/2013-15/05/2013 </h3></a>
    <p>
      Group Exhibition with <a href="https://www.diasfineart.co.uk/" target="_blank">Joe Dias</a>
    </p>
  </li>

  <li>
    <a href="{{'/assets/images/posterII_3x2_1800.jpg ' | relative_url}}" target="_blank">
      <h3>U-Hang @ Art Gene, Barrow in Furness - 04/2014 </h3>
    </a>
    <p>
      Exhibited with <a href="https://www.art-gene.co.uk/" target="blank">Art Gene</a> at the beautiful Nan Tait Centre in Barrow, a contemporary art association in the Furness Peninsula.
    </p>
  </li>
</ol>
</section>