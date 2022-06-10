﻿// <auto-generated />
using System;
using Duende.IdentityServer.EntityFramework.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace id.Migrations.ConfigurationDb
{
    [DbContext(typeof(ConfigurationDbContext))]
    partial class ConfigurationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.5");

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("AllowedAccessTokenSigningAlgorithms")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireResourceIndicator")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApiResources", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId", "Type")
                        .IsUnique();

                    b.ToTable("ApiResourceClaims", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId", "Key")
                        .IsUnique();

                    b.ToTable("ApiResourceProperties", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId", "Scope")
                        .IsUnique();

                    b.ToTable("ApiResourceScopes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ApiResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ApiResourceId");

                    b.ToTable("ApiResourceSecrets", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Emphasize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Required")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("ApiScopes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ScopeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScopeId", "Type")
                        .IsUnique();

                    b.ToTable("ApiScopeClaims", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<int>("ScopeId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ScopeId", "Key")
                        .IsUnique();

                    b.ToTable("ApiScopeProperties", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AbsoluteRefreshTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccessTokenType")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowAccessTokensViaBrowser")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowOfflineAccess")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowPlainTextPkce")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AllowRememberConsent")
                        .HasColumnType("INTEGER");

                    b.Property<string>("AllowedIdentityTokenSigningAlgorithms")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<bool>("AlwaysIncludeUserClaimsInIdToken")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AlwaysSendClientClaims")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AuthorizationCodeLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("BackChannelLogoutSessionRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BackChannelLogoutUri")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("CibaLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientClaimsPrefix")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("ClientUri")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConsentLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool?>("CoordinateLifetimeWithUserSession")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<int>("DeviceCodeLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("EnableLocalLogin")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("FrontChannelLogoutSessionRequired")
                        .HasColumnType("INTEGER");

                    b.Property<string>("FrontChannelLogoutUri")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<int>("IdentityTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IncludeJwtId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<string>("LogoUri")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PairWiseSubjectSalt")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int?>("PollingInterval")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProtocolType")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<int>("RefreshTokenExpiration")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RefreshTokenUsage")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireClientSecret")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireConsent")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequirePkce")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("RequireRequestObject")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SlidingRefreshTokenLifetime")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("UpdateAccessTokenClaimsOnRefresh")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserCodeType")
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserSsoLifetime")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ClientId")
                        .IsUnique();

                    b.ToTable("Clients", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "Type", "Value")
                        .IsUnique();

                    b.ToTable("ClientClaims", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "Origin")
                        .IsUnique();

                    b.ToTable("ClientCorsOrigins", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("GrantType")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "GrantType")
                        .IsUnique();

                    b.ToTable("ClientGrantTypes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Provider")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "Provider")
                        .IsUnique();

                    b.ToTable("ClientIdPRestrictions", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("PostLogoutRedirectUri")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "PostLogoutRedirectUri")
                        .IsUnique();

                    b.ToTable("ClientPostLogoutRedirectUris", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "Key")
                        .IsUnique();

                    b.ToTable("ClientProperties", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RedirectUri")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "RedirectUri")
                        .IsUnique();

                    b.ToTable("ClientRedirectUris", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientScope", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Scope")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId", "Scope")
                        .IsUnique();

                    b.ToTable("ClientScopes", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClientId")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Expiration")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(4000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.ToTable("ClientSecrets", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityProvider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("LastAccessed")
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Properties")
                        .HasColumnType("TEXT");

                    b.Property<string>("Scheme")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Scheme")
                        .IsUnique();

                    b.ToTable("IdentityProviders", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResource", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Created")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("TEXT");

                    b.Property<string>("DisplayName")
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("Emphasize")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Enabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.Property<bool>("NonEditable")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Required")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("ShowInDiscoveryDocument")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime?>("Updated")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("IdentityResources", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityResourceId", "Type")
                        .IsUnique();

                    b.ToTable("IdentityResourceClaims", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("IdentityResourceId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Key")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(2000)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("IdentityResourceId", "Key")
                        .IsUnique();

                    b.ToTable("IdentityResourceProperties", (string)null);
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceClaim", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceProperty", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Properties")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceScope", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Scopes")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResourceSecret", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiResource", "ApiResource")
                        .WithMany("Secrets")
                        .HasForeignKey("ApiResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApiResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScopeClaim", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("UserClaims")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scope");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScopeProperty", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.ApiScope", "Scope")
                        .WithMany("Properties")
                        .HasForeignKey("ScopeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scope");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientClaim", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("Claims")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientCorsOrigin", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedCorsOrigins")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientGrantType", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedGrantTypes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientIdPRestriction", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("IdentityProviderRestrictions")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientPostLogoutRedirectUri", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("PostLogoutRedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientProperty", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("Properties")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientRedirectUri", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("RedirectUris")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientScope", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("AllowedScopes")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ClientSecret", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.Client", "Client")
                        .WithMany("ClientSecrets")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Client");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResourceClaim", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("UserClaims")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResourceProperty", b =>
                {
                    b.HasOne("Duende.IdentityServer.EntityFramework.Entities.IdentityResource", "IdentityResource")
                        .WithMany("Properties")
                        .HasForeignKey("IdentityResourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("IdentityResource");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiResource", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("Scopes");

                    b.Navigation("Secrets");

                    b.Navigation("UserClaims");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.ApiScope", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("UserClaims");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.Client", b =>
                {
                    b.Navigation("AllowedCorsOrigins");

                    b.Navigation("AllowedGrantTypes");

                    b.Navigation("AllowedScopes");

                    b.Navigation("Claims");

                    b.Navigation("ClientSecrets");

                    b.Navigation("IdentityProviderRestrictions");

                    b.Navigation("PostLogoutRedirectUris");

                    b.Navigation("Properties");

                    b.Navigation("RedirectUris");
                });

            modelBuilder.Entity("Duende.IdentityServer.EntityFramework.Entities.IdentityResource", b =>
                {
                    b.Navigation("Properties");

                    b.Navigation("UserClaims");
                });
#pragma warning restore 612, 618
        }
    }
}
