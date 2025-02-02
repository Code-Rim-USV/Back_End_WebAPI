toc.dat                                                                                             0000600 0004000 0002000 00000035117 14740751223 0014453 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        PGDMP   3                      }            examplanner    17.1    17.1 1    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                           false         �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                           false                     0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                           false                    1262    18125    examplanner    DATABASE     �   CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';
    DROP DATABASE examplanner;
                     postgres    false                     2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                     pg_database_owner    false                    0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                        pg_database_owner    false    4         �            1259    18126    exams_sq    SEQUENCE     v   CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;
    DROP SEQUENCE public.exams_sq;
       public               postgres    false    4         �            1259    18127    Exams    TABLE     z  CREATE TABLE public."Exams" (
    "ExamID" integer DEFAULT nextval('public.exams_sq'::regclass) NOT NULL,
    "Group" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "AssistantID" integer,
    "Date" date NOT NULL,
    "Start_Time" character varying(30) NOT NULL,
    "LocationID" integer NOT NULL,
    "Duration" integer NOT NULL
);
    DROP TABLE public."Exams";
       public         heap r       postgres    false    217    4         �            1259    18131    HasRoles    TABLE     m   CREATE TABLE public."HasRoles" (
    "UserID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);
    DROP TABLE public."HasRoles";
       public         heap r       postgres    false    4         �            1259    18134    locations_sq    SEQUENCE     z   CREATE SEQUENCE public.locations_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;
 #   DROP SEQUENCE public.locations_sq;
       public               postgres    false    4         �            1259    18135 	   Locations    TABLE     �   CREATE TABLE public."Locations" (
    "LocationID" integer DEFAULT nextval('public.locations_sq'::regclass) NOT NULL,
    "LocationName" character varying(100) NOT NULL
);
    DROP TABLE public."Locations";
       public         heap r       postgres    false    220    4         �            1259    18139    requests_sq    SEQUENCE     z   CREATE SEQUENCE public.requests_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000000
    CACHE 1;
 "   DROP SEQUENCE public.requests_sq;
       public               postgres    false    4         �            1259    18140    Requests    TABLE     N  CREATE TABLE public."Requests" (
    "RequestID" integer DEFAULT nextval('public.requests_sq'::regclass) NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "Group" integer NOT NULL,
    "Date" date NOT NULL,
    "Status" character varying(30) NOT NULL,
    "RejectionReason" character varying(200)
);
    DROP TABLE public."Requests";
       public         heap r       postgres    false    222    4         �            1259    18144    StudentGroup    TABLE     d   CREATE TABLE public."StudentGroup" (
    "UserID" integer NOT NULL,
    "Group" integer NOT NULL
);
 "   DROP TABLE public."StudentGroup";
       public         heap r       postgres    false    4         �            1259    18147    subjects_sq    SEQUENCE     x   CREATE SEQUENCE public.subjects_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;
 "   DROP SEQUENCE public.subjects_sq;
       public               postgres    false    4         �            1259    18148    Subjects    TABLE     �   CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "ProfessorID" integer NOT NULL,
    "SubjectName" character varying(100) NOT NULL
);
    DROP TABLE public."Subjects";
       public         heap r       postgres    false    225    4         �            1259    18152    users_sq    SEQUENCE     u   CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;
    DROP SEQUENCE public.users_sq;
       public               postgres    false    4         �            1259    18153    Users    TABLE     '  CREATE TABLE public."Users" (
    "UserID" integer DEFAULT nextval('public.users_sq'::regclass) NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "LastName" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Password" character varying(50) NOT NULL
);
    DROP TABLE public."Users";
       public         heap r       postgres    false    227    4         �          0    18127    Exams 
   TABLE DATA           �   COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "LocationID", "Duration") FROM stdin;
    public               postgres    false    218       4849.dat �          0    18131    HasRoles 
   TABLE DATA           6   COPY public."HasRoles" ("UserID", "Role") FROM stdin;
    public               postgres    false    219       4850.dat �          0    18135 	   Locations 
   TABLE DATA           C   COPY public."Locations" ("LocationID", "LocationName") FROM stdin;
    public               postgres    false    221       4852.dat �          0    18140    Requests 
   TABLE DATA           {   COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM stdin;
    public               postgres    false    223       4854.dat �          0    18144    StudentGroup 
   TABLE DATA           ;   COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
    public               postgres    false    224       4855.dat �          0    18148    Subjects 
   TABLE DATA           O   COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM stdin;
    public               postgres    false    226       4857.dat �          0    18153    Users 
   TABLE DATA           Y   COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
    public               postgres    false    228       4859.dat            0    0    exams_sq    SEQUENCE SET     7   SELECT pg_catalog.setval('public.exams_sq', 32, true);
          public               postgres    false    217                    0    0    locations_sq    SEQUENCE SET     ;   SELECT pg_catalog.setval('public.locations_sq', 58, true);
          public               postgres    false    220                    0    0    requests_sq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.requests_sq', 50, true);
          public               postgres    false    222                    0    0    subjects_sq    SEQUENCE SET     :   SELECT pg_catalog.setval('public.subjects_sq', 70, true);
          public               postgres    false    225                    0    0    users_sq    SEQUENCE SET     8   SELECT pg_catalog.setval('public.users_sq', 268, true);
          public               postgres    false    227         C           2606    18158    Exams Exams_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "Exams_pkey" PRIMARY KEY ("ExamID");
 >   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "Exams_pkey";
       public                 postgres    false    218         E           2606    18160    HasRoles HasRoles_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "HasRoles_pkey" PRIMARY KEY ("UserID", "Role");
 D   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "HasRoles_pkey";
       public                 postgres    false    219    219         G           2606    18162    Locations Locations_pkey 
   CONSTRAINT     d   ALTER TABLE ONLY public."Locations"
    ADD CONSTRAINT "Locations_pkey" PRIMARY KEY ("LocationID");
 F   ALTER TABLE ONLY public."Locations" DROP CONSTRAINT "Locations_pkey";
       public                 postgres    false    221         M           2606    18164    StudentGroup StudentGroup_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");
 L   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT "StudentGroup_pkey";
       public                 postgres    false    224         I           2606    18166    Locations Unique_Locations 
   CONSTRAINT     c   ALTER TABLE ONLY public."Locations"
    ADD CONSTRAINT "Unique_Locations" UNIQUE ("LocationName");
 H   ALTER TABLE ONLY public."Locations" DROP CONSTRAINT "Unique_Locations";
       public                 postgres    false    221         O           2606    18168    Subjects Unique_subjects 
   CONSTRAINT     `   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT "Unique_subjects" UNIQUE ("SubjectName");
 F   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT "Unique_subjects";
       public                 postgres    false    226         S           2606    18170    Users Unique_users 
   CONSTRAINT     T   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Unique_users" UNIQUE ("Email");
 @   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Unique_users";
       public                 postgres    false    228         U           2606    18172    Users Users_pkey 
   CONSTRAINT     X   ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");
 >   ALTER TABLE ONLY public."Users" DROP CONSTRAINT "Users_pkey";
       public                 postgres    false    228         K           2606    18174    Requests pk_request 
   CONSTRAINT     \   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT pk_request PRIMARY KEY ("RequestID");
 ?   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT pk_request;
       public                 postgres    false    223         Q           2606    18176    Subjects subjects_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT subjects_pkey PRIMARY KEY ("SubjectID");
 B   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT subjects_pkey;
       public                 postgres    false    226         V           2606    18177    Exams FK_exams_locations    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_locations" FOREIGN KEY ("LocationID") REFERENCES public."Locations"("LocationID") MATCH FULL NOT VALID;
 F   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_locations";
       public               postgres    false    221    218    4679         W           2606    18182    Exams FK_exams_subjects    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_subjects" FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 E   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_subjects";
       public               postgres    false    4689    226    218         X           2606    18187    Exams FK_exams_users_1    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_1" FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_1";
       public               postgres    false    218    4693    228         Y           2606    18192    Exams FK_exams_users_2    FK CONSTRAINT     �   ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_2" FOREIGN KEY ("AssistantID") REFERENCES public."Users"("UserID") MATCH FULL;
 D   ALTER TABLE ONLY public."Exams" DROP CONSTRAINT "FK_exams_users_2";
       public               postgres    false    228    218    4693         Z           2606    18197    HasRoles FK_hasroles_users    FK CONSTRAINT     �   ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "FK_hasroles_users" FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;
 H   ALTER TABLE ONLY public."HasRoles" DROP CONSTRAINT "FK_hasroles_users";
       public               postgres    false    219    4693    228         ]           2606    18202    StudentGroup fk_group_user    FK CONSTRAINT     �   ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");
 F   ALTER TABLE ONLY public."StudentGroup" DROP CONSTRAINT fk_group_user;
       public               postgres    false    224    228    4693         [           2606    18207    Requests fk_req_prof    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_prof FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;
 @   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_prof;
       public               postgres    false    4693    223    228         \           2606    18212    Requests fk_req_sub    FK CONSTRAINT     �   ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_sub FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;
 ?   ALTER TABLE ONLY public."Requests" DROP CONSTRAINT fk_req_sub;
       public               postgres    false    226    223    4689         ^           2606    18217    Subjects fk_subjects_users    FK CONSTRAINT     �   ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT fk_subjects_users FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL NOT VALID;
 F   ALTER TABLE ONLY public."Subjects" DROP CONSTRAINT fk_subjects_users;
       public               postgres    false    228    226    4693                                                                                                                                                                                                                                                                                                                                                                                                                                                         4849.dat                                                                                            0000600 0004000 0002000 00000000206 14740751223 0014265 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        30	3141	63	251	248	2025-03-10	12:00PM	51	2
31	3141	66	256	255	2025-03-22	16:00PM	55	2
32	3143	63	251	252	2025-03-10	10:00PM	51	2
\.


                                                                                                                                                                                                                                                                                                                                                                                          4850.dat                                                                                            0000600 0004000 0002000 00000000545 14740751223 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        248	Assistant
248	Professor
249	Professor
250	Professor
251	Professor
252	Professor
253	Professor
254	Professor
255	Assistant
256	Assistant
256	Professor
257	Assistant
258	Assistant
258	Professor
259	Assistant
260	Assistant
261	Student
262	GroupLeader
262	Student
263	Student
264	Student
265	Student
266	GroupLeader
266	Student
267	Student
268	Student
\.


                                                                                                                                                           4852.dat                                                                                            0000600 0004000 0002000 00000000165 14740751223 0014263 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        51	C201
52	C202
53	C203
54	C204
55	C301
56	C303
57	Amfiteatrul Dimitrie Hurmuzescu
58	Amfiteatrul Remus Radulet
\.


                                                                                                                                                                                                                                                                                                                                                                                                           4854.dat                                                                                            0000600 0004000 0002000 00000000346 14740751223 0014266 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        45	61	248	3141	2025-03-14	Pending	\N
46	61	248	3143	2025-03-14	Pending	\N
47	65	248	3141	2025-03-16	Pending	\N
48	63	251	3141	2025-03-10	Accepted	\N
49	63	251	3143	2025-03-10	Accepted	\N
50	66	256	3141	2025-03-22	Accepted	\N
\.


                                                                                                                                                                                                                                                                                          4855.dat                                                                                            0000600 0004000 0002000 00000000115 14740751223 0014261 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        261	3141
262	3141
263	3141
264	3141
265	3141
266	3143
267	3143
268	3143
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                                   4857.dat                                                                                            0000600 0004000 0002000 00000000521 14740751223 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        61	248	Proiectarea Translatoarelor
62	251	Elemente de grafică pe calculator
63	251	Inteligență artificială
64	251	Programarea interfețelor utilizator
65	248	Sisteme Inteligente
66	256	Metode Numerice
67	250	Protocoale de comunicații
68	250	Structura și organizarea calculatoarelor
69	254	Fizică 2
70	258	Matematici speciale
\.


                                                                                                                                                                               4859.dat                                                                                            0000600 0004000 0002000 00000002121 14740751223 0014264 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        248	Ovidiu	Gherman	ovidiug@eed.usv.ro	OG12345
249	Simona-Anda	Tcaciuc	tcaciuc.anda@usm.ro	ST12345
250	Ionel	Zagan	zagan@eed.usv.ro	IZ12345
251	Cristina	Turcu	cristina@usm.ro	CT12345
252	Catalin	Beguni	catalin.beguni@usm.ro	CB12345
253	Aurelia	Pascut	aurelia@usm.ro	AP12345
254	Andrei	Diaconu	andrei.diaconu@usm.ro	AD12345
255	Sorin	Pohoata	sorinp@eed.usv.ro	SP12345
256	Marius	Prelipceanu	marius.prelipceanu@usm.ro	MP12345
257	Aurelian	Rotaru	rotaru@eed.usv.ro	AR12345
258	Bianca	Satco	bisatco@eed.usv.ro	BS12345
259	Eugen	Hopulele	eugenh@eed.usv.ro	EH12345
260	Radu Dumitru	Pentiuc	radup@eed.usv.ro	RP12345
261	Stefan	Ilculesei-Meglei	stefan.ilculesei@student.usv.ro	SI12345
262	Stefan	Rosca	stefan.rosca@student.usv.ro	SR12345
263	Alexandru	Munteanu	alexandru.munteanu6@student.usv.ro	AM12345
264	Alexandra	Joroveanu	alexandra.joroveanu@student.usv.ro	AJ12345
265	Mert	Aydogan	aydogan.mert@student.usv.ro	MA12345
266	Bogdan	Tibuleac	bogdan.tibuleac@student.usv.ro	BT12345
267	Andrei	Aluculesei	andrei.aluculesei@student.usv.ro	BT12345
268	Timotei	Moscaliuc	timotei.moscaliuc@student.usv.ro	TM12345
\.


                                                                                                                                                                                                                                                                                                                                                                                                                                               restore.sql                                                                                         0000600 0004000 0002000 00000027520 14740751223 0015377 0                                                                                                    ustar 00postgres                        postgres                        0000000 0000000                                                                                                                                                                        --
-- NOTE:
--
-- File paths need to be edited. Search for $$PATH$$ and
-- replace it with the path to the directory containing
-- the extracted data files.
--
--
-- PostgreSQL database dump
--

-- Dumped from database version 17.1
-- Dumped by pg_dump version 17.1

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE examplanner;
--
-- Name: examplanner; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE examplanner WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'English_United States.1252';


ALTER DATABASE examplanner OWNER TO postgres;

\connect examplanner

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET transaction_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--
-- Name: public; Type: SCHEMA; Schema: -; Owner: pg_database_owner
--

CREATE SCHEMA public;


ALTER SCHEMA public OWNER TO pg_database_owner;

--
-- Name: SCHEMA public; Type: COMMENT; Schema: -; Owner: pg_database_owner
--

COMMENT ON SCHEMA public IS 'standard public schema';


--
-- Name: exams_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.exams_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;


ALTER SEQUENCE public.exams_sq OWNER TO postgres;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- Name: Exams; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Exams" (
    "ExamID" integer DEFAULT nextval('public.exams_sq'::regclass) NOT NULL,
    "Group" integer NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "AssistantID" integer,
    "Date" date NOT NULL,
    "Start_Time" character varying(30) NOT NULL,
    "LocationID" integer NOT NULL,
    "Duration" integer NOT NULL
);


ALTER TABLE public."Exams" OWNER TO postgres;

--
-- Name: HasRoles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."HasRoles" (
    "UserID" integer NOT NULL,
    "Role" character varying(30) NOT NULL
);


ALTER TABLE public."HasRoles" OWNER TO postgres;

--
-- Name: locations_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.locations_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 1000000
    CACHE 1;


ALTER SEQUENCE public.locations_sq OWNER TO postgres;

--
-- Name: Locations; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Locations" (
    "LocationID" integer DEFAULT nextval('public.locations_sq'::regclass) NOT NULL,
    "LocationName" character varying(100) NOT NULL
);


ALTER TABLE public."Locations" OWNER TO postgres;

--
-- Name: requests_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.requests_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 10000000
    CACHE 1;


ALTER SEQUENCE public.requests_sq OWNER TO postgres;

--
-- Name: Requests; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Requests" (
    "RequestID" integer DEFAULT nextval('public.requests_sq'::regclass) NOT NULL,
    "SubjectID" integer NOT NULL,
    "ProfessorID" integer NOT NULL,
    "Group" integer NOT NULL,
    "Date" date NOT NULL,
    "Status" character varying(30) NOT NULL,
    "RejectionReason" character varying(200)
);


ALTER TABLE public."Requests" OWNER TO postgres;

--
-- Name: StudentGroup; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."StudentGroup" (
    "UserID" integer NOT NULL,
    "Group" integer NOT NULL
);


ALTER TABLE public."StudentGroup" OWNER TO postgres;

--
-- Name: subjects_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.subjects_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;


ALTER SEQUENCE public.subjects_sq OWNER TO postgres;

--
-- Name: Subjects; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Subjects" (
    "SubjectID" integer DEFAULT nextval('public.subjects_sq'::regclass) NOT NULL,
    "ProfessorID" integer NOT NULL,
    "SubjectName" character varying(100) NOT NULL
);


ALTER TABLE public."Subjects" OWNER TO postgres;

--
-- Name: users_sq; Type: SEQUENCE; Schema: public; Owner: postgres
--

CREATE SEQUENCE public.users_sq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 100000
    CACHE 1;


ALTER SEQUENCE public.users_sq OWNER TO postgres;

--
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "UserID" integer DEFAULT nextval('public.users_sq'::regclass) NOT NULL,
    "FirstName" character varying(50) NOT NULL,
    "LastName" character varying(50) NOT NULL,
    "Email" character varying(100) NOT NULL,
    "Password" character varying(50) NOT NULL
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- Data for Name: Exams; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "LocationID", "Duration") FROM stdin;
\.
COPY public."Exams" ("ExamID", "Group", "SubjectID", "ProfessorID", "AssistantID", "Date", "Start_Time", "LocationID", "Duration") FROM '$$PATH$$/4849.dat';

--
-- Data for Name: HasRoles; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."HasRoles" ("UserID", "Role") FROM stdin;
\.
COPY public."HasRoles" ("UserID", "Role") FROM '$$PATH$$/4850.dat';

--
-- Data for Name: Locations; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Locations" ("LocationID", "LocationName") FROM stdin;
\.
COPY public."Locations" ("LocationID", "LocationName") FROM '$$PATH$$/4852.dat';

--
-- Data for Name: Requests; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM stdin;
\.
COPY public."Requests" ("RequestID", "SubjectID", "ProfessorID", "Group", "Date", "Status", "RejectionReason") FROM '$$PATH$$/4854.dat';

--
-- Data for Name: StudentGroup; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."StudentGroup" ("UserID", "Group") FROM stdin;
\.
COPY public."StudentGroup" ("UserID", "Group") FROM '$$PATH$$/4855.dat';

--
-- Data for Name: Subjects; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM stdin;
\.
COPY public."Subjects" ("SubjectID", "ProfessorID", "SubjectName") FROM '$$PATH$$/4857.dat';

--
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM stdin;
\.
COPY public."Users" ("UserID", "FirstName", "LastName", "Email", "Password") FROM '$$PATH$$/4859.dat';

--
-- Name: exams_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.exams_sq', 32, true);


--
-- Name: locations_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.locations_sq', 58, true);


--
-- Name: requests_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.requests_sq', 50, true);


--
-- Name: subjects_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.subjects_sq', 70, true);


--
-- Name: users_sq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.users_sq', 268, true);


--
-- Name: Exams Exams_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "Exams_pkey" PRIMARY KEY ("ExamID");


--
-- Name: HasRoles HasRoles_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "HasRoles_pkey" PRIMARY KEY ("UserID", "Role");


--
-- Name: Locations Locations_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Locations"
    ADD CONSTRAINT "Locations_pkey" PRIMARY KEY ("LocationID");


--
-- Name: StudentGroup StudentGroup_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT "StudentGroup_pkey" PRIMARY KEY ("UserID");


--
-- Name: Locations Unique_Locations; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Locations"
    ADD CONSTRAINT "Unique_Locations" UNIQUE ("LocationName");


--
-- Name: Subjects Unique_subjects; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT "Unique_subjects" UNIQUE ("SubjectName");


--
-- Name: Users Unique_users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Unique_users" UNIQUE ("Email");


--
-- Name: Users Users_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "Users_pkey" PRIMARY KEY ("UserID");


--
-- Name: Requests pk_request; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT pk_request PRIMARY KEY ("RequestID");


--
-- Name: Subjects subjects_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT subjects_pkey PRIMARY KEY ("SubjectID");


--
-- Name: Exams FK_exams_locations; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_locations" FOREIGN KEY ("LocationID") REFERENCES public."Locations"("LocationID") MATCH FULL NOT VALID;


--
-- Name: Exams FK_exams_subjects; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_subjects" FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;


--
-- Name: Exams FK_exams_users_1; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_1" FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: Exams FK_exams_users_2; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Exams"
    ADD CONSTRAINT "FK_exams_users_2" FOREIGN KEY ("AssistantID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: HasRoles FK_hasroles_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."HasRoles"
    ADD CONSTRAINT "FK_hasroles_users" FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: StudentGroup fk_group_user; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."StudentGroup"
    ADD CONSTRAINT fk_group_user FOREIGN KEY ("UserID") REFERENCES public."Users"("UserID");


--
-- Name: Requests fk_req_prof; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_prof FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL;


--
-- Name: Requests fk_req_sub; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Requests"
    ADD CONSTRAINT fk_req_sub FOREIGN KEY ("SubjectID") REFERENCES public."Subjects"("SubjectID") MATCH FULL;


--
-- Name: Subjects fk_subjects_users; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Subjects"
    ADD CONSTRAINT fk_subjects_users FOREIGN KEY ("ProfessorID") REFERENCES public."Users"("UserID") MATCH FULL NOT VALID;


--
-- PostgreSQL database dump complete
--

                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                